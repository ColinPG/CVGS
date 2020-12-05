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
            public string Street { get; set; }
            [Display(Name = "Postal Code")]
            public string PostalCode { get; set; }
            public string City { get; set; }
            [Display(Name = "Apartment Number")]
            public string ApartmentNumber { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Country")]
            public string CountryCode { get; set; }
        }

        public void OnGet(bool isMailing)
        {
            _isMailing = isMailing;
            FillViewData(isMailing);
        }

        private void FillViewData(bool isMailing)
        {
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

        public async Task<IActionResult> OnPostAsync(bool isMailing)
        {
            _isMailing = isMailing;
            //Street 
            if (String.IsNullOrEmpty(Input.Street))
                ModelState.AddModelError("Input.Street", "Street is required.");
            else if (Input.Street.Length > 20)
                ModelState.AddModelError("Input.Street", "Street must be 20 or less characters");
            else if (Input.Street.Length < 2)
                ModelState.AddModelError("Input.Street", "Street must be 2 or more characters");
            //Postal Code
            if (String.IsNullOrWhiteSpace(Input.PostalCode))
                ModelState.AddModelError("Input.PostalCode", "Postal Code required.");
            else if (!ModelValidations.PostalCodeValidation(Input.PostalCode))
                ModelState.AddModelError("Input.PostalCode", "Invalid Postal Code.");
            //City 
            if (String.IsNullOrEmpty(Input.City))
                ModelState.AddModelError("Input.City", "City is required.");
            else if (Input.City.Length > 20)
                ModelState.AddModelError("Input.City", "City must be 20 or less characters");
            else if (Input.City.Length < 2)
                ModelState.AddModelError("Input.City", "City must be 2 or more characters");
            //Apartment Number
            if (!String.IsNullOrEmpty(Input.ApartmentNumber))
            {
                if (Input.ApartmentNumber.Length > 20)
                    ModelState.AddModelError("Input.ApartmentNumber", "Apartment Number must be 20 or less characters");
                else if (Input.ApartmentNumber.Length < 2)
                    ModelState.AddModelError("Input.ApartmentNumber", "Apartment Number must be 2 or more characters");
            }
            //First Name
            if (String.IsNullOrEmpty(Input.FirstName))
                ModelState.AddModelError("Input.FirstName", "First Name is required.");
            else if (Input.FirstName.Length > 20)
                ModelState.AddModelError("Input.FirstName", "First Name must be 20 or less characters");
            else if (Input.FirstName.Length < 2)
                ModelState.AddModelError("Input.FirstName", "First Name must be 2 or more characters");
            //Last Name
            if (String.IsNullOrEmpty(Input.LastName))
                ModelState.AddModelError("Input.LastName", "LastName is required.");
            else if (Input.LastName.Length > 20)
                ModelState.AddModelError("Input.LastName", "LastName must be 20 or less characters");
            else if (Input.LastName.Length < 2)
                ModelState.AddModelError("Input.LastName", "LastName must be 2 or more characters");
            if (!ModelState.IsValid)
            {
                FillViewData(isMailing);
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
                    ProvinceCode = null,
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
                    ProvinceCode = null,
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
