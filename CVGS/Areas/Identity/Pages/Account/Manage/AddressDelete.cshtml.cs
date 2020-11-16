using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CVGS.Areas.Identity.Pages.Account.Manage
{
    public class AddressDeleteModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly CVGSContext _context;
        public AddressDeleteModel(
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
            public int Id { get; set; }
            public string Street { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }
            public string ApartmentNumber { get; set; }
            public string Province { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public async Task<IActionResult> OnGet(bool isMailing, int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            _isMailing = isMailing;
            if (_isMailing)
            {
                var address = _context.AddressMailing.Where(a => a.MailingId == id).FirstOrDefault();
                if (address.UserId != user.Id)
                {
                    StatusMessage = "Unauthorized to delete this address.";
                    return RedirectToPage("Addresses");
                }
                Input = new InputModel
                {
                    Id = address.MailingId,
                    FirstName = address.FirstName,
                    LastName = address.LastName,
                    City = address.City,
                    ApartmentNumber = address.ApartmentNumber,
                    PostalCode = address.PostalCode,
                    Province = address.Province,
                    Street = address.Street
                };
            }
            else
            {
                var address = _context.AddressShipping.Where(a => a.ShippingId == id).FirstOrDefault();
                if (address.UserId != user.Id)
                {
                    StatusMessage = "Unauthorized to delete this address.";
                    return RedirectToPage("Addresses");
                }
                Input = new InputModel
                {
                    Id = address.ShippingId,
                    FirstName = address.FirstName,
                    LastName = address.LastName,
                    City = address.City,
                    ApartmentNumber = address.ApartmentNumber,
                    PostalCode = address.PostalCode,
                    Province = address.Province,
                    Street = address.Street
                };
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(bool isMailing, int id)
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
            if (_isMailing)
            {
                var address = _context.AddressMailing.Where(a => a.MailingId == id).FirstOrDefault();
                _context.Remove(address);
                StatusMessage = "Mailing Address deleted.";
            }
            else
            {
                var address = _context.AddressShipping.Where(a => a.ShippingId == id).FirstOrDefault();
                _context.Remove(address);
                StatusMessage = "Shipping Address deleted.";
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("Addresses");
        }
    }
}
