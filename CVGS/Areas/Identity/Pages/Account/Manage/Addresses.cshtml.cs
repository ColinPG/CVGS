using System;
using System.Collections.Generic;
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
    public class AddressesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly CVGSContext _context;

        public AddressesModel(
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

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            public List<AddressMailing> addressMailings { get; set; }
            public List<AddressShipping> addressShippings { get; set; }
        }
        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Input = new InputModel
            {
                addressMailings = _context.AddressMailing.Where(a => a.UserId == user.Id).ToList(),
                addressShippings = _context.AddressShipping.Where(a => a.UserId == user.Id).ToList()
            };
            return Page();
        }

        public string AddressSummary(Guid id, bool isMailing)
        {
            string result = "";
           

            if (isMailing)
            {
                var address = _context.AddressMailing.Include(a => a.CountryCodeNavigation).Include(a => a.ProvinceCodeNavigation).Where(a => a.MailingId == id).FirstOrDefault();
                string province = "";
                if(!String.IsNullOrEmpty(address.ProvinceCode))
                    province = ModelValidations.Capitilize(address.ProvinceCodeNavigation.EnglishName);
                result = "<b> Street </b> <br/>" +address.Street + "<br/> <b>City</b> <br/>" + address.City + "<br/> <b>Province</b> <br/> "
                    + province + " <br/> <b>Postal Code</b> <br/>" + address.PostalCode + " <br/> <b>Country</b> <br/>" + ModelValidations.Capitilize(address.CountryCodeNavigation.EnglishName);
            

            }
            else // Shipping
            {
                var address = _context.AddressShipping.Include(a => a.CountryCodeNavigation).Include(a => a.ProvinceCodeNavigation).Where(a => a.ShippingId == id).FirstOrDefault();
                string province = "";
                if (!String.IsNullOrEmpty(address.ProvinceCode))
                    province = ModelValidations.Capitilize(address.ProvinceCodeNavigation.EnglishName);
                result = "<b> Street </b> <br/>" + address.Street + "<br/> <b>City</b> <br/>" + address.City + "<br/> <b>Province</b> <br/> "
                     + province + " <br/> <b>Postal Code</b> <br/>" + address.PostalCode + " <br/> <b>Country</b> <br/>" + ModelValidations.Capitilize(address.CountryCodeNavigation.EnglishName);

            }
            return result;
        }
    }
}
