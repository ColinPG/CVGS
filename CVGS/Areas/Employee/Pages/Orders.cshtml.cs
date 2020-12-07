using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CVGS.Areas.Employee.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly CVGSContext _context;

        public OrdersModel(
            UserManager<User> userManager,
            CVGSContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public List<Order> orders;
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
                orders = _context.Order
                    .Include(a => a.Mailing)
                    .Include(a => a.Shipping)
                    .Include(a => a.User).OrderByDescending(a => a.DateCreated).ToList(),
            };
            return Page();
        }
    }
}
