using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CVGS.Areas.Identity.Pages.Account
{
    public class GameLibraryModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CVGSContext _context;

        public GameLibraryModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            CVGSContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            public List<UserGameLibraryItem> libraryItems { get; set; }
            public bool allFormatsSelected { get; set; }
            public string userName { get; set; }
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
                libraryItems = _context.UserGameLibraryItem
                    .Include(a => a.User)
                    .Include(a => a.Game)
                    .Include(g => g.Game.EsrbRatingCodeNavigation)
                    .Include(g => g.Game.GameCategory)
                    .Include(g => g.Game.GamePerspectiveCodeNavigation)
                    .Include(g => g.Game.GameFormatCodeNavigation)
                    .Include(g => g.Game.GameSubCategory)
                    .Where(a => a.UserId == user.Id)
                    .OrderByDescending(g => g.DatePurchased).ToList(),
                userName = user.UserName
            };            
            return Page();
        }
    }
}
