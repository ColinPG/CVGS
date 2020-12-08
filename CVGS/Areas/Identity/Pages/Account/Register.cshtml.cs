using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CVGS.Models;

namespace CVGS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Display(Name = "Email")]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Display(Name = "Gamer Tag")]
            public string GamerTag { get; set; }

            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Receive Promotional Emails?")]
            public bool PromoEmailEnabled { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            //UserName
            if (String.IsNullOrEmpty(Input.UserName))
                ModelState.AddModelError("Input.UserName", "User Name is required.");
            else if (Input.UserName.Length > 25)
                ModelState.AddModelError("Input.UserName", "User Name must be 25 or less characters");
            else if (Input.UserName.Length < 3)
                ModelState.AddModelError("Input.UserName", "User Name must be 3 or more characters");
            //Email
            if (String.IsNullOrEmpty(Input.Email))
                ModelState.AddModelError("Input.Email", "Email is required.");
            else if (!ModelValidations.ValidEmail(Input.Email))
                ModelState.AddModelError("Input.Email", "Invalid Email. Ex. email@address.com");
            //Phone Number
            if (String.IsNullOrEmpty(Input.PhoneNumber))
                ModelState.AddModelError("Input.PhoneNumber", "Phone Number is required.");
            else if (!ModelValidations.ValidPhoneNumber(Input.PhoneNumber))
                ModelState.AddModelError("Input.PhoneNumber", "Invalid Phone Number. Ex. 000-000-0000");
            //Password
            if(String.IsNullOrEmpty(Input.Password))
                ModelState.AddModelError("Input.Password", "Password is required.");
            else if (Input.Password.Length > 100)
                ModelState.AddModelError("Input.Password", "Password must be 100 or less characters");
            else if (Input.Password.Length < 6)
                ModelState.AddModelError("Input.Password", "Password must be 6 or more characters");
            //Confirm Password
            if (Input.ConfirmPassword != Input.Password)
                ModelState.AddModelError("Input.ConfirmPassword", "The password and confirmation password do not match.");
            //GamerTag
            if (String.IsNullOrEmpty(Input.GamerTag))
                ModelState.AddModelError("Input.GamerTag", "Gamer Tag is required.");
            else if (Input.GamerTag.Length > 25)
                ModelState.AddModelError("Input.GamerTag", "Gamer Tag must be 25 or less characters");
            else if (Input.GamerTag.Length < 3)
                ModelState.AddModelError("Input.GamerTag", "Gamer Tag must be 3 or more characters");
            if (ModelState.IsValid)
            {
                var user = new User { 
                    UserName = Input.UserName, 
                    Email = Input.Email, 
                    PhoneNumber = Input.PhoneNumber,
                    GamerTag = Input.GamerTag, 
                    Bio = "", 
                    PromoEmailEnabled = Input.PromoEmailEnabled};
                if (user.GamerTag == null)
                    user.GamerTag = "";
                var result = await _userManager.CreateAsync(user, Input.Password);
                if(result.Succeeded)
                    result = await _userManager.AddToRoleAsync(user, "members");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    TempData["message"] = $"Account: {Input.UserName} created.";

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
