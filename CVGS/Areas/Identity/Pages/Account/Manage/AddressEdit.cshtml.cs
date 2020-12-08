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
    public class AddressEditModel : PageModel
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly CVGSContext _context;
        public AddressEditModel(
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
            [Display(Name = "Province")]
            public string ProvinceCode { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display (Name = "Country")]
            public string CountryCode { get; set; }
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
                var address = _context.AddressMailing.Where(a => a.MailingId.ToString() == id).FirstOrDefault();
                if (address == null)
                {
                    StatusMessage = "Address not found.";
                    return RedirectToPage("Addresses");
                }
                if (address.UserId != user.Id)
                {
                    StatusMessage = "Unauthorized to edit this address.";
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
                    ProvinceCode = address.ProvinceCode,
                    Street = address.Street,
                    CountryCode = address.CountryCode
                };
            }
            else
            {
                var address = _context.AddressShipping.Where(a => a.ShippingId.ToString() == id).FirstOrDefault();
                if (address == null)
                {
                    StatusMessage = "Address not found.";
                    return RedirectToPage("Addresses");
                }
                if (address.UserId != user.Id)
                {
                    StatusMessage = "Unauthorized to edit this address.";
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
                    ProvinceCode = address.ProvinceCode,
                    Street = address.Street,
                    CountryCode = address.CountryCode
                };
            }
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
            return Page();
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
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (_isMailing)
            {
                AddressMailing newAddress = new AddressMailing
                {
                    MailingId = Guid.Parse(Input.Id),
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    ApartmentNumber = Input.ApartmentNumber,
                    PostalCode = Input.PostalCode,
                    ProvinceCode = Input.ProvinceCode,
                    Street = Input.Street,
                    CountryCode = Input.CountryCode,
                    LastModified = DateTime.Now,
                    Archived = false,
                    UserId = user.Id
                };
                if (!ValidCountry(Input.CountryCode))
                {
                    newAddress.ProvinceCode = null;
                }
                if (newAddress.ApartmentNumber == null)
                    newAddress.ApartmentNumber = "";
                _context.Update(newAddress);
                StatusMessage = "Mailing Address updated.";
            }
            else
            {
                AddressShipping newAddress = new AddressShipping
                {
                    ShippingId = Guid.Parse(Input.Id),
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    City = Input.City,
                    ApartmentNumber = Input.ApartmentNumber,
                    PostalCode = Input.PostalCode,
                    ProvinceCode = Input.ProvinceCode,
                    Street = Input.Street,
                    CountryCode = Input.CountryCode,
                    LastModified = DateTime.Now,
                    Archived = false,
                    UserId = user.Id
                };
                if (!ValidCountry(Input.CountryCode))
                {
                    newAddress.ProvinceCode = null;
                }
                if (newAddress.ApartmentNumber == null)
                    newAddress.ApartmentNumber = "";
                _context.Update(newAddress);
                StatusMessage = "Shipping Address updated.";
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
