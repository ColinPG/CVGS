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
    public class PersonalInformationModel : PageModel
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public PersonalInformationModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Display(Name = "Bio")]
            public string Bio { get; set; }
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Range(typeof(DateTime), "1/1/1900", "11/11/2020",
                ErrorMessage = "Date of Birth cannot be in the future.")]
            [Display(Name = "Date Of Birth")]
            public DateTime? DateOfBirth { get; set; }
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Gender")]
            public string Gender { get; set; }
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Country")]
            public string Country { get; set; }
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Province/State")]
            public string ProvinceState { get; set; }
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
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

            Input = new InputModel
            {
                Bio = user.Bio,
                City = user.City,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                ProvinceState = user.ProvinceState
            };

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.Bio = Input.Bio;
            user.City = Input.City;
            user.Country = Input.Country;
            user.DateOfBirth = Input.DateOfBirth;
            user.Gender = Input.Gender;
            user.ProvinceState = Input.ProvinceState;
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your Personal Information has been updated";
            return RedirectToPage();
        }
    }
}
