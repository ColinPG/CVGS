using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVGS.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly CVGSContext _context;

        public IndexModel(
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

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            [EmailAddress]
            public string Email { get; set; }
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Gamer Tag")]
            public string GamerTag { get; set; }
            [Display(Name  = "Recieving Promotional Emails")]
            public bool PromotionalEmail { get; set; }
            [Display(Name = "Bio")]
            public string Bio { get; set; }
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Display(Name = "Date Of Birth")]
            public DateTime? DateOfBirth { get; set; }
            [Display(Name = "Gender")]
            public string Gender { get; set; }
            [Display(Name = "Country")]
            public string CountryCode { get; set; }
            [Display(Name = "Province")]
            public string ProvinceCode { get; set; }
            [Display(Name = "City")]
            public string City { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var gamerTag = user.GamerTag;
            var promotionalEmail = user.PromoEmailEnabled;

            Input = new InputModel
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phoneNumber,
                GamerTag = gamerTag,
                PromotionalEmail = promotionalEmail,
                Bio = user.Bio,
                City = user.City,
                CountryCode = user.CountryCode,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                ProvinceCode = user.ProvinceCode
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            FillViewData();
            return Page();
        }

        private void FillViewData()
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
            ViewData["Countries"] = countries;
            ViewData["Provinces"] = provinces;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //Email
            if (!ModelValidations.ValidEmail(Input.Email))
                ModelState.AddModelError("Input.Email", "Invalid Email. Ex. email@address.com");
            //Phone Number
            if (!ModelValidations.ValidPhoneNumber(Input.PhoneNumber))
                ModelState.AddModelError("Input.PhoneNumber", "Invalid Phone Number. Ex. 000-000-0000");
            //Bio
            user.Bio = Input.Bio;
            if (String.IsNullOrEmpty(user.Bio))
                user.Bio = "";
            //First Name
            if (String.IsNullOrEmpty(Input.FirstName))
                user.FirstName = "";
            else if (Input.FirstName.Length > 25)
                ModelState.AddModelError("Input.FirstName", "First Name must be less than 25 characters");
            else
                user.FirstName = Input.FirstName;
            //Last Name
            if (String.IsNullOrEmpty(Input.LastName))
                user.LastName = "";
            else if (Input.LastName.Length > 25)
                ModelState.AddModelError("Input.LastName", "Last Name must be less than 25 characters");
            else
                user.LastName = Input.LastName;
            //City
            if (String.IsNullOrEmpty(Input.City))
                user.City = "";
            else if (Input.City.Length > 25)
                ModelState.AddModelError("Input.City", "City must be less than 25 characters");
            else
                user.City = Input.City;
            //Gender
            if (String.IsNullOrEmpty(Input.Gender))
                user.Gender = "";
            else if (Input.Gender.Length > 25)
                ModelState.AddModelError("Input.Gender", "Gender must be less than 25 characters");
            else
                user.Gender = Input.Gender;
            //GamerTag
            if (String.IsNullOrEmpty(Input.GamerTag))
                user.GamerTag = "";
            else if (Input.GamerTag.Length > 25)
                ModelState.AddModelError("Input.GamerTag", "GamerTag must be less than 25 characters");
            else
                user.GamerTag = Input.GamerTag;
            //Date of Birth
            if (Input.DateOfBirth > DateTime.Now)
                ModelState.AddModelError("Input.DateOfBirth", "Date of Birth can not be past current date.");
            else
                user.DateOfBirth = Input.DateOfBirth;
            //CountryCode
            bool hideStatusMessage = false;
            if (Input.CountryCode != user.CountryCode)
            {
                hideStatusMessage = true;
            }
            user.CountryCode = Input.CountryCode;
            //ProvinceCode
            if (!ValidCountry(Input.CountryCode))
            {
                user.ProvinceCode = null;
            }
            else
                user.ProvinceCode = Input.ProvinceCode;
            if (!ModelState.IsValid)
            {
                FillViewData();
                return Page();
            }
            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            var promotionalEmail = user.PromoEmailEnabled;
            if (Input.PromotionalEmail != promotionalEmail)
            {
                user.PromoEmailEnabled = Input.PromotionalEmail;
            }


            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            if (User.IsInRole("administrators"))
                TempData["message"] = "Profile updated.";
            if (!hideStatusMessage)
                StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
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
