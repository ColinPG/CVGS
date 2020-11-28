using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            [StringLength(20, ErrorMessage = "No information entered for Street.", MinimumLength = 1)]
            public string Street { get; set; }
            [Required]
            [Display(Name = "Postal Code")]
            [StringLength(6, ErrorMessage = "Postal code must be 6 characters long.", MinimumLength = 6)]
            public string PostalCode { get; set; }
            [Required]
            [StringLength(20, ErrorMessage = "No information entered for City.", MinimumLength = 1)]
            public string City { get; set; }
            [Display(Name = "Apartment Number")]
            [StringLength(20, ErrorMessage = "No information entered for Apartment Number.")]
            public string ApartmentNumber { get; set; }
            [Display(Name = "Province")]
            public string ProvinceCode { get; set; }
            [Required]
            [Display(Name = "First Name")]
            [StringLength(20, ErrorMessage = "No information entered for First name.", MinimumLength = 1)]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            [StringLength(20, ErrorMessage = "No information entered for Last name.", MinimumLength = 1)]
            public string LastName { get; set; }
            [Display(Name = "Country")]
            public string CountryCode { get; set; }
        }

        public void OnGet(bool isMailing)
        {
            _isMailing = isMailing;
            SelectList countries = new SelectList(_context.Country.OrderBy(a => a.EnglishName), "Code", "EnglishName");
            foreach (SelectListItem i in countries)
            {
                i.Text = ModelValidations.Capitilize(i.Text);
            }
            Input = new InputModel
            {
                CountryCode = null
            };
            ViewData["CountryCode"] = countries;
        }

        public void OnGet(bool isMailing, string code)
        {
            SelectList countries = new SelectList(_context.Country.OrderBy(a => a.EnglishName), "Code", "EnglishName");
            foreach (SelectListItem i in countries)
            {
                i.Text = ModelValidations.Capitilize(i.Text);
            }
            SelectList provinces = new SelectList(_context.Province.Where(a => a.CountryCode == Input.CountryCode).OrderBy(a => a.EnglishName), "Code", "EnglishName");
            foreach (SelectListItem i in provinces)
            {
                i.Text = ModelValidations.Capitilize(i.Text);
            }
            ViewData["CountryCode"] = countries;
            ViewData["ProvinceCode"] = provinces;
        }

        public async Task<IActionResult> OnPostAsync(bool isMailing)
        {
            _isMailing = isMailing;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!ModelValidations.PostalCodeValidation(Input.PostalCode))
            {
                ModelState.AddModelError("Input.PostalCode", "Invalid Postal Code.");
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
                    MailingId = Guid.NewGuid(),
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    ApartmentNumber = Input.ApartmentNumber,
                    PostalCode = Input.PostalCode,
                    ProvinceCode = Input.ProvinceCode,
                    Street = Input.Street,
                    CountryCode = Input.CountryCode,
                    LastModified = DateTime.Now,
                    UserId = user.Id
                };
                if (!ValidCountry(Input.CountryCode))
                {
                    newAddress.ProvinceCode = null;
                }
                if (newAddress.ApartmentNumber == null)
                    newAddress.ApartmentNumber = "";
                _context.Add(newAddress);
                StatusMessage = "New Mailing Address added.";
            }
            else
            {
                AddressShipping newAddress = new AddressShipping
                {
                    ShippingId = Guid.NewGuid(),
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    ApartmentNumber = Input.ApartmentNumber,
                    PostalCode = Input.PostalCode,
                    ProvinceCode = Input.ProvinceCode,
                    Street = Input.Street,
                    CountryCode = Input.CountryCode,
                    LastModified = DateTime.Now,
                    UserId = user.Id
                };
                if (!ValidCountry(Input.CountryCode))
                {
                    newAddress.ProvinceCode = null;
                }
                if (newAddress.ApartmentNumber == null)
                    newAddress.ApartmentNumber = "";
                _context.Add(newAddress);
                StatusMessage = "New Shipping Address added.";
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("Addresses");
        }

        public bool ValidCountry(string countryCode)
        {
            if (_context.Province.Where(a => a.CountryCode == countryCode).Any())
                return true;
            else
                return false;
        }
    }
}
