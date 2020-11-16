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

namespace CVGS.Areas.Identity.Pages.Account.Manage
{
    public class AddressAddModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly CVGSContext _context;
        public AddressAddModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            CVGSContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _context = context;
        }

        public bool _isMailing;

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Street { get; set; }
            [Required]
            [StringLength(6, ErrorMessage = "Postal code must be 6 characters long.", MinimumLength = 6)]
            public string PostalCode { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string ApartmentNumber { get; set; }
            [Required]
            public string Province { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
        }
        public void OnGet(bool isMailing)
        {
            _isMailing = isMailing;
        }

        public async Task<IActionResult> OnPostAsync(bool isMailing)
        {
            _isMailing = isMailing;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if(_isMailing)
            {
                AddressMailing newAddress = new AddressMailing
                {
                    MailingId = _context.AddressMailing.Count() + 1,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    ApartmentNumber = Input.ApartmentNumber,
                    PostalCode = Input.PostalCode,
                    Province = Input.Province,
                    Street = Input.Street,
                    LastModified = DateTime.Now,
                    UserId = user.Id
                };
                _context.Add(newAddress);
                StatusMessage = "New Mailing Address added.";
            }
            else
            {
                AddressShipping newAddress = new AddressShipping
                {
                    ShippingId = _context.AddressMailing.Count() + 1,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    ApartmentNumber = Input.ApartmentNumber,
                    PostalCode = Input.PostalCode,
                    Province = Input.Province,
                    Street = Input.Street,
                    LastModified = DateTime.Now,
                    UserId = user.Id
                };
                _context.Add(newAddress);
                StatusMessage = "New Shipping Address added.";
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("Addresses");
        }
    }
}
