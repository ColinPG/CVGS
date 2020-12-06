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
    public class WishListModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CVGSContext _context;

        public WishListModel(
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
            public List<WishListItem> wishListItems { get; set; }
            public bool allFormatsSelected { get; set; }
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
                wishListItems = _context.WishListItem
                .Include(a => a.Game)
                .Include(g => g.Game.EsrbRatingCodeNavigation)
                .Include(g => g.Game.GameCategory)
                .Include(g => g.Game.GamePerspectiveCodeNavigation)
                .Include(g => g.Game.GameFormatCodeNavigation)
                .Include(g => g.Game.GameSubCategory)
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(g => g.DateCreated).ToList()
            };
            Input.allFormatsSelected = true;
            
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var wishListItems = _context.WishListItem.Include(a => a.Game)                
                .Include(g => g.Game.EsrbRatingCodeNavigation)
                .Include(g => g.Game.GameCategory)
                .Include(g => g.Game.GamePerspectiveCodeNavigation)
                .Include(g => g.Game.GameFormatCodeNavigation)
                .Include(g => g.Game.GameSubCategory)
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(g => g.DateCreated).ToList();
            await _context.SaveChangesAsync();
            StatusMessage = "";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAdd(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var game = _context.Game.Include(a => a.GameFormatCodeNavigation).Where(a => a.Guid == id).FirstOrDefault();


            //otherwise, add new Wish List item.
            WishListItem newWishListItem = new WishListItem()
            {
                GameId = id,
                
                DateCreated = DateTime.Now,
                UserId = user.Id,
               
            };
            _context.WishListItem.Add(newWishListItem);
            StatusMessage = $"{game.EnglishName} added to cart.";

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemove(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var wishListitem = _context.WishListItem.Where(a => a.GameId == id && a.UserId == user.Id).FirstOrDefault();
            _context.WishListItem.Remove(wishListitem);
            await _context.SaveChangesAsync();
            StatusMessage = "Item removed from cart.";
            return RedirectToPage();
        }
    }
}
