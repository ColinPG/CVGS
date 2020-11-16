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
    public class ChangePreferencesModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly CVGSContext _context;

        public ChangePreferencesModel(
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
        public PreferenceInputModel preferenceInputModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class PreferenceInputModel
        {
            public string AddValue { get; set; }
            public bool AllSelected { get; set; }
            public List<PlatformPreference> platformSelected { get; set; }
            public List<CategoryPreference> categorySelected { get; set; }
            public List<SubCategoryPreference> subCategorySelected { get; set; }
            public List<Platform> platforms { get; set; }
            public List<GameCategory> categories { get; set; }
            public List<GameSubCategory> subCategories { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            preferenceInputModel = new PreferenceInputModel
            {
                platformSelected = await _context.PlatformPreference
                    .Include(g => g.PlatformCodeNavigation)
                    .Where(g => g.UserId == user.Id)
                    .OrderBy(a => a.LastModified)
                    .ToListAsync(),
                platforms = await _context.Platform
                    .ToListAsync(),
                categorySelected = await _context.CategoryPreference
                    .Include(g => g.Gamecategory)
                    .Where(g => g.UserId == user.Id)
                    .OrderBy(a => a.LastModified)
                    .ToListAsync(),
                categories = await _context.GameCategory
                    .ToListAsync(),
                subCategorySelected = await _context.SubCategoryPreference
                    .Include(g => g.GameSubcategory)
                    .Where(g => g.UserId == user.Id)
                    .OrderBy(a => a.LastModified)
                    .ToListAsync(),
                subCategories = await _context.GameSubCategory
                    .ToListAsync()
            };
            if (preferenceInputModel.categories.Count == preferenceInputModel.categorySelected.Count &&
                preferenceInputModel.platforms.Count == preferenceInputModel.platformSelected.Count &&
                preferenceInputModel.subCategories.Count == preferenceInputModel.subCategorySelected.Count)
                preferenceInputModel.AllSelected = true;
            else
                preferenceInputModel.AllSelected = false;
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

            var platPref = _context.Platform.Where(a => a.EnglishName == preferenceInputModel.AddValue).FirstOrDefault();
            if (platPref != null)
            {
                _context.PlatformPreference.Add(
                    new PlatformPreference { UserId = user.Id, PlatformCode = platPref.Code, LastModified = DateTime.Now });
                StatusMessage = $"Preference Platform {preferenceInputModel.AddValue} has been added.";
            }
            var catPref = _context.GameCategory.Where(a => a.EnglishCategory == preferenceInputModel.AddValue).FirstOrDefault();
            if (catPref != null)
            {
                _context.CategoryPreference.Add(
                    new CategoryPreference { UserId = user.Id, GamecategoryId = catPref.Id, LastModified = DateTime.Now });
                StatusMessage = $"Preference Category {preferenceInputModel.AddValue} has been added.";
            }
            var subcatPref = _context.GameSubCategory.Where(a => a.EnglishCategory == preferenceInputModel.AddValue).FirstOrDefault();
            if(subcatPref != null) {
                _context.SubCategoryPreference.Add(
                    new SubCategoryPreference { UserId = user.Id, GameSubcategoryId = subcatPref.Id, LastModified = DateTime.Now });
                StatusMessage = $"Preference Subcategory {preferenceInputModel.AddValue} has been added.";
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemove(string id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var platPref = _context.PlatformPreference
                .Include(a => a.PlatformCodeNavigation)
                .Where(a => a.PlatformCodeNavigation.EnglishName == id && a.User.Id == user.Id)
                .FirstOrDefault();
            if (platPref != null)
            {
                _context.PlatformPreference.Remove(platPref);
                StatusMessage = $"Preference Platform {platPref.PlatformCodeNavigation.EnglishName} has been removed.";
            }
            var catPref = _context.CategoryPreference
                .Include(a => a.Gamecategory)
                .Where(a => a.Gamecategory.EnglishCategory == id && a.User.Id == user.Id)
                .FirstOrDefault();
            if (catPref != null)
            {
                _context.CategoryPreference.Remove(catPref);
                StatusMessage = $"Preference Category {catPref.Gamecategory.EnglishCategory} has been removed.";
            }
            var subCatPref = _context.SubCategoryPreference
                .Include(a => a.GameSubcategory)
                .Where(a => a.GameSubcategory.EnglishCategory == id && a.User.Id == user.Id)
                .FirstOrDefault();
            if (subCatPref != null)
            {
                _context.SubCategoryPreference.Remove(subCatPref);
                StatusMessage = $"Preference SubCategory {subCatPref.GameSubcategory.EnglishCategory} has been removed.";
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
        public bool PlatformPrefExists(string name)
        {
            var userid = _userManager.GetUserId(User);
            return _context.PlatformPreference.
                Include(a => a.PlatformCodeNavigation)
                .Any(a => a.PlatformCodeNavigation.EnglishName == name && a.UserId == userid);
        }

        public bool CategoryPrefExists(string name)
        {
            var userid = _userManager.GetUserId(User);
            return _context.CategoryPreference.
                Include(a => a.Gamecategory)
                .Any(a => a.Gamecategory.EnglishCategory == name && a.UserId == userid);
        }

        public bool SubCategoryPrefExists(string name)
        {
            var userid = _userManager.GetUserId(User);
            return _context.SubCategoryPreference.
                Include(a => a.GameSubcategory)
                .Any(a => a.GameSubcategory.EnglishCategory == name && a.UserId == userid);
        }
    }
}
