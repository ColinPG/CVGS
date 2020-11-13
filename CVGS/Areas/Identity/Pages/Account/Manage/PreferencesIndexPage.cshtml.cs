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
    public class PreferencesIndexPageModel : PageModel
    {
        
      
        private readonly CVGSContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public PreferencesIndexPageModel(CVGSContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender)
        {

            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;


        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //Prefrences info
            var platformPrefrence = _context.PlatformPreference
               .Include(g => g.PlatformCodeNavigation)
               .Where(g =>g.UserId==user.Id);

            var categoryPreference = _context.CategoryPreference
                .Include(g => g.Gamecategory)
                .Where(g => g.UserId == user.Id);

            var subcatgoryPreference = _context.SubCategoryPreference
                .Include(g => g.GameSubcategory)
                .Where(g => g.UserId == user.Id); 
               
          ViewData["platformPreference"] = _context.PlatformPreference
               .Include(g => g.PlatformCodeNavigation)
               .Include(g => g.User).ToString();
            ViewData["categoryPreference"] = _context.CategoryPreference
                .Include(g => g.Gamecategory)
                .Include(g => g.User).ToString();

            ViewData["subcatgoryPreference"] = _context.SubCategoryPreference
                .Include(g => g.GameSubcategory)
                .Include(g => g.User).ToList();
            return Page();
        }



    }
}
