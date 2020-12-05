using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CVGS.Areas.Identity.Pages.Account
{
    public class CartCheckoutModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly CVGSContext _context;

        public CartCheckoutModel(
            UserManager<User> userManager,
            CVGSContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        private const double taxRate = 0.13f;
        public class InputModel
        {
            public List<CartItem> cartItems { get; set; }
            public List<AddressMailing> addressMailings { get; set; }
            public List<AddressShipping> addressShippings { get; set; }
            [Display(Name = "Credit Card Number")]
            public string creditCardNumber { get; set; }
            [Display(Name = "Security Code")]
            public string securityCode { get; set; }
            [Display(Name = "Year")]
            public string year { get; set; }
            [Display(Name = "Month")]
            public string month { get; set; }
            [Display(Name = "Sub Total")]
            [DataType(DataType.Currency)]
            public double subTotal { get; set; }
            [Display(Name = "Final Total")]
            [DataType(DataType.Currency)]
            public double finalTotal { get; set; }
            [Display(Name = "Tax")]
            public double taxRate { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Input = new InputModel
            {
                cartItems = _context.CartItem.Include(a => a.Game)
                    .Include(g => g.Game.EsrbRatingCodeNavigation)
                    .Include(g => g.Game.GameCategory)
                    .Include(g => g.Game.GamePerspectiveCodeNavigation)
                    .Include(g => g.Game.GameFormatCodeNavigation)
                    .Include(g => g.Game.GameSubCategory)
                    .Where(a => a.UserId == user.Id)
                    .OrderByDescending(g => g.LastModified).ToList(),
                addressMailings = _context.AddressMailing.Include(a => a.ProvinceCodeNavigation)
                    .Include(a => a.CountryCodeNavigation).ToList(),
                addressShippings = _context.AddressShipping.Include(a => a.ProvinceCodeNavigation)
                    .Include(a => a.CountryCodeNavigation).ToList(),
                subTotal = 0,
                finalTotal = 0,
                taxRate = taxRate,
            };
            foreach (CartItem item in Input.cartItems)
            {
                Input.subTotal += (double)(item.Game.Price * item.Quantity);
            }
            Input.finalTotal = (Input.subTotal * (1 + Input.taxRate));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return RedirectToPage();
        }
    }
}
