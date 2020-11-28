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
            public string Id { get; set; }
            public string Street { get; set; }
            [Display(Name = "Postal Code")]
            public string PostalCode { get; set; }
            public string City { get; set; }
            [Display(Name = "Apartment Number")]
            public string ApartmentNumber { get; set; }
            public string Province { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Country")]
            public string CountryCode { get; set; }
            public virtual Country CountryNavigation { get; set; }
        }

        public async Task<IActionResult> OnGet(bool isMailing, string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            _isMailing = isMailing;
            if (_isMailing)
            {
                var address = _context.AddressMailing.Include(a => a.ProvinceCodeNavigation).Where(a => a.MailingId.ToString() == id).FirstOrDefault();
                if (address == null)
                {
                    StatusMessage = "Address not found.";
                    return RedirectToPage("Addresses");
                }
                if (address.UserId != user.Id)
                {
                    StatusMessage = "Unauthorized to delete this address.";
                    return RedirectToPage("Addresses");
                }
                Input = new InputModel
                {
                    Id = address.MailingId.ToString(),
                    FirstName = address.FirstName,
                    LastName = address.LastName,
                    City = address.City,
                    ApartmentNumber = address.ApartmentNumber,
                    PostalCode = address.PostalCode,
                    Street = address.Street,
                    CountryCode = address.CountryCode
                };
                if (String.IsNullOrWhiteSpace(address.ApartmentNumber))
                    Input.ApartmentNumber = "N/A";
                if (!String.IsNullOrEmpty(address.ProvinceCode))
                    Input.Province = ModelValidations.Capitilize(address.ProvinceCodeNavigation.EnglishName);
                else
                    Input.Province = "N/A";
                Input.CountryCode = ModelValidations.Capitilize(_context.Country.Where(a => a.Code == address.CountryCode).FirstOrDefault().EnglishName);
            }
            else
            {
                var address = _context.AddressShipping.Include(a => a.ProvinceCodeNavigation).Where(a => a.ShippingId.ToString() == id).FirstOrDefault();
                if (address == null)
                {
                    StatusMessage = "Address not found.";
                    return RedirectToPage("Addresses");
                }
                if (address.UserId != user.Id)
                {
                    StatusMessage = "Unauthorized to delete this address.";
                    return RedirectToPage("Addresses");
                }
                Input = new InputModel
                {
                    Id = address.ShippingId.ToString(),
                    FirstName = address.FirstName,
                    LastName = address.LastName,
                    City = address.City,
                    ApartmentNumber = address.ApartmentNumber,
                    PostalCode = address.PostalCode,
                    Street = address.Street,
                    CountryCode = address.CountryCode
                };
                if (String.IsNullOrWhiteSpace(address.ApartmentNumber))
                    Input.ApartmentNumber = "N/A";
                if (!String.IsNullOrWhiteSpace(address.ProvinceCode))
                    Input.Province = ModelValidations.Capitilize(address.ProvinceCodeNavigation.EnglishName);
                else
                    Input.Province = "N/A";
                Input.CountryCode = ModelValidations.Capitilize(_context.Country.Where(a => a.Code == address.CountryCode).FirstOrDefault().EnglishName);
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(bool isMailing, string id)
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
                var address = _context.AddressMailing.Where(a => a.MailingId.ToString() == id).FirstOrDefault();
                _context.Remove(address);
                StatusMessage = "Mailing Address deleted.";
            }
            else
            {
                var address = _context.AddressShipping.Where(a => a.ShippingId.ToString() == id).FirstOrDefault();
                _context.Remove(address);
                StatusMessage = "Shipping Address deleted.";
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("Addresses");
        }
    }
}
