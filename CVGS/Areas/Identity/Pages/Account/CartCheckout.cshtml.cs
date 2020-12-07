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
using Microsoft.AspNetCore.Mvc.Rendering;
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
            public string mailingSelected { get; set; }
            public string shipppingSelected { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            FillInputModel(user);
            if (Input.cartItems.Count != 0 && Input.finalTotal == 0)
            {
                await AddGamesToAccount(Input.cartItems, user);
                TempData["successMessage"] = "All games in cart were free! Added to account.";
                return RedirectToAction("Index", "Home");
            }
            if (Input.addressMailings.Count == 0 || Input.addressShippings.Count == 0)
            {
                TempData["message"] = "Checking out requires a shipping or mailing address.";
                return RedirectToPage("Manage/Addresses");
            }
            foreach(CartItem item in Input.cartItems)
            {
                if (item.GameFormatCode == "B")
                {
                    TempData["message"] = "Checking out requires all game formats to be selected.";
                    return RedirectToPage("CartIndex");
                }
            }

            return Page();
        }

        private async Task AddGamesToAccount(List<CartItem> cartItems, User user)
        {
            Order newOrder = new Order()
            {
                Id = Guid.NewGuid(),
                IsShipped = true,
                DateCreated = DateTime.Now,
                UserId = user.Id,
            };
            if (!String.IsNullOrEmpty(Input.mailingSelected))
                newOrder.MailingId = Guid.Parse(Input.mailingSelected);
            if (!String.IsNullOrEmpty(Input.shipppingSelected))
                newOrder.ShippingId = Guid.Parse(Input.shipppingSelected);
            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();
            foreach (CartItem item in Input.cartItems)
            {
                OrderItem oItem = new OrderItem()
                {
                    GameId = item.GameId,
                    LastModified = DateTime.Now,
                    OrderId = newOrder.Id,
                    Quantity = item.Quantity,
                    GameFormatCode = item.GameFormatCode
                };
                var isInLibrary = _context.UserGameLibraryItem.Where(a => a.GameId == item.GameId && a.UserId == user.Id).Any();
                if (!isInLibrary)
                {
                    UserGameLibraryItem newLibraryItem = new UserGameLibraryItem()
                    {
                        GameId = item.GameId,
                        UserId = user.Id,
                        DatePurchased = DateTime.Now,
                    };
                    _context.UserGameLibraryItem.Add(newLibraryItem);
                }
                if (oItem.GameFormatCode == "P")
                    newOrder.IsShipped = false;
                _context.OrderItem.Add(oItem);
                _context.CartItem.Remove(item);
            }
            _context.Order.Update(newOrder);
            await _context.SaveChangesAsync();
        }

        private void FillInputModel(User user)
        {
            Input = new InputModel
            {
                cartItems = _context.CartItem.Include(a => a.Game)
                    .Include(a => a.GameFormatCodeNavigation)
                    .Include(g => g.Game.EsrbRatingCodeNavigation)
                    .Include(g => g.Game.GameCategory)
                    .Include(g => g.Game.GamePerspectiveCodeNavigation)
                    .Include(g => g.Game.GameFormatCodeNavigation)
                    .Include(g => g.Game.GameSubCategory)
                    .Where(a => a.UserId == user.Id)
                    .OrderByDescending(g => g.LastModified).ToList(),
                addressMailings = _context.AddressMailing
                    .Include(a => a.ProvinceCodeNavigation)
                    .Include(a => a.CountryCodeNavigation)
                    .Where(a => a.UserId == user.Id).ToList(),
                addressShippings = _context.AddressShipping
                    .Include(a => a.ProvinceCodeNavigation)
                    .Include(a => a.CountryCodeNavigation)
                    .Where(a => a.UserId == user.Id).ToList(),
                subTotal = 0,
                finalTotal = 0,
                taxRate = taxRate,
            };
            foreach (CartItem item in Input.cartItems)
            {
                Input.subTotal += (double)(item.Game.Price * item.Quantity);
            }
            Input.finalTotal = (Input.subTotal * (1 + Input.taxRate));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //AddressMailingSelected
            if(String.IsNullOrWhiteSpace(Input.mailingSelected)) 
                ModelState.AddModelError("Input.addressMailings", "Mailing Address is required.");
            //AddressShippingSelected
            if (String.IsNullOrWhiteSpace(Input.shipppingSelected))
                ModelState.AddModelError("Input.addressShippings", "Shipping Address is required.");
            //creditCardNumber
            if (String.IsNullOrWhiteSpace(Input.creditCardNumber))
                ModelState.AddModelError("Input.creditCardNumber", "Credit Card Number is required.");
            else if (!ModelValidations.IsStringNumeric(Input.creditCardNumber))
                ModelState.AddModelError("Input.creditCardNumber", "Credit Card Number is not numeric.");
            else if (Input.creditCardNumber.Length != 16)
                ModelState.AddModelError("Input.creditCardNumber", "Credit Card Number must be 16 digits.");
            //securityCode
            if (String.IsNullOrWhiteSpace(Input.securityCode))
                ModelState.AddModelError("Input.securityCode", "Security Code is required.");
            else if (!ModelValidations.IsStringNumeric(Input.securityCode))
                ModelState.AddModelError("Input.securityCode", "Security Code is not numeric.");
            else if (Input.securityCode.Length != 3)
                ModelState.AddModelError("Input.securityCode", "Security Code must be 3 digits.");
            //month
            int monthRes = 13;
            if (String.IsNullOrWhiteSpace(Input.month))
                ModelState.AddModelError("Input.month", "Month is required.");
            else if (!int.TryParse(Input.month, out monthRes))
                ModelState.AddModelError("Input.month", "Month is not a valid number.");
            else if (Input.month.Length != 2)
                ModelState.AddModelError("Input.month", "Month must be 2 digits. Ex. 03, 12");
            else if (monthRes < 1 || monthRes > 12)
                ModelState.AddModelError("Input.month", "Month is out of range, must be between 1-12.");
            else
            {
                //Add to order ?
            }
            //year
            if (String.IsNullOrWhiteSpace(Input.year))
                ModelState.AddModelError("Input.year", "Year is required.");
            else if (!int.TryParse(Input.year, out int yearRes))
                ModelState.AddModelError("Input.year", "Year is not a valid number.");
            else if (Input.year.Length != 2)
                ModelState.AddModelError("Input.year", "Year must be 2 digits.");
            else if (yearRes == (DateTime.Now.Year - 2000))
            {
                if (monthRes < DateTime.Now.Month)
                    ModelState.AddModelError("Input.year", "Date is in the past.");
            }
            else if (yearRes < (DateTime.Now.Year - 2000) || yearRes > 99)
                ModelState.AddModelError("Input.year", $"Year is out of range, must be between {String.Format("{0:00}", (DateTime.Now.Year - 2000))}-99.");
            else
            {
                //Add to order ?
            }
            if (!ModelState.IsValid)
            {
                FillInputModel(user);
                return Page();
            }
            //Add new order to db
            await AddGamesToAccount(Input.cartItems, user);
            TempData["successMessage"] = "Order succesfully placed!";
            return RedirectToAction("Index", "Home");
        }
    }
}
