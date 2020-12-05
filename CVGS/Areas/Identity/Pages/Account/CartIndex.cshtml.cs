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

namespace CVGS.Areas.Identity.Pages.Account
{
    public class CartIndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CVGSContext _context;

        public CartIndexModel(
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
            public List<CartItem> cartItems { get; set; }
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
                cartItems = _context.CartItem.Include(a => a.Game)
                .Include(g => g.Game.EsrbRatingCodeNavigation)
                .Include(g => g.Game.GameCategory)
                .Include(g => g.Game.GamePerspectiveCodeNavigation)
                .Include(g => g.Game.GameFormatCodeNavigation)
                .Include(g => g.Game.GameSubCategory)
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(g => g.LastModified).ToList()
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var cartItems = _context.CartItem.Include(a => a.Game)
                .Include(g => g.Game.EsrbRatingCodeNavigation)
                .Include(g => g.Game.GameCategory)
                .Include(g => g.Game.GamePerspectiveCodeNavigation)
                .Include(g => g.Game.GameFormatCodeNavigation)
                .Include(g => g.Game.GameSubCategory)
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(g => g.LastModified).ToList();
            for (int i = 0; i < cartItems.Count; i++)
            {
                if (cartItems[i].Quantity != Input.cartItems[i].Quantity)
                {
                    cartItems[i].Quantity = Input.cartItems[i].Quantity;
                    _context.CartItem.Update(cartItems[i]);
                }
            }
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
            var game = _context.Game.Where(a => a.Guid == id).FirstOrDefault();
            //Check if exists, if it does, add 1 to quantity 
            var cartItem = _context.CartItem.Where(a => a.GameId == id && a.UserId == user.Id).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Quantity += 1;
                _context.CartItem.Update(cartItem);
                StatusMessage = $"Another {game.EnglishName} added to cart.";
            }
            else
            {
                //otherwise, add new cart item.
                CartItem newCartItem = new CartItem()
                {
                    GameId = id,
                    Quantity = 1,
                    LastModified = DateTime.Now,
                    UserId = user.Id
                };
                _context.CartItem.Add(newCartItem);
                StatusMessage = $"{game.EnglishName} added to cart.";
            }
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
            var cartItem =  _context.CartItem.Where(a => a.GameId == id && a.UserId == user.Id).FirstOrDefault();
            _context.CartItem.Remove(cartItem);
            await _context.SaveChangesAsync();
            StatusMessage = "Item removed from cart.";
            return RedirectToPage();
        }
    }
}
