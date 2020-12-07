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
    public class OrderDetailsModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly CVGSContext _context;

        public OrderDetailsModel(
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
        private const double taxRate = 0.13f;

        public class InputModel
        {
            [Display(Name = "Order Id")]
            public Guid Id { get; set; }
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            [Display(Name = "Status")]
            public bool IsShipped { get; set; }
            [Display(Name = "Date Ordered")]
            public DateTime? DateCreated { get; set; }
            [Display(Name = "Sub Total")]
            [DataType(DataType.Currency)]
            public double subTotal { get; set; }
            [Display(Name = "Final Total")]
            [DataType(DataType.Currency)]
            public double finalTotal { get; set; }
            [Display(Name = "Tax")]
            public double taxRate { get; set; }
            public List<OrderItem> orderItems { get; set; }
            public AddressMailing addressMailing { get; set; }
            public AddressShipping addressShipping { get; set; }
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound($"Order Id missing or invalid.");
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await FillInputModel(id, user);
            return Page();
        }

        private async Task FillInputModel(string id, User user)
        {
            var order = _context.Order.Include(a => a.User).Where(a => a.Id.ToString() == id).FirstOrDefault();
            var oItems = await _context.OrderItem.Include(a => a.Game).Include(a => a.GameFormatCodeNavigation).Where(a => a.OrderId.ToString() == id).ToListAsync();
            Input = new InputModel
            {
                Id = order.Id,
                DateCreated = order.DateCreated,
                IsShipped = (bool)order.IsShipped,
                UserName = order.User.UserName,
                orderItems = oItems,
                subTotal = 0,
                finalTotal = 0,
                taxRate = taxRate,
            };
            if (order.MailingId != null)
                Input.addressMailing = _context.AddressMailing.Include(a => a.CountryCodeNavigation).Include(a => a.ProvinceCodeNavigation).Where(a => a.UserId == order.UserId && a.MailingId == order.MailingId).FirstOrDefault();
            if (order.ShippingId != null)
                Input.addressShipping = _context.AddressShipping.Include(a => a.CountryCodeNavigation).Include(a => a.ProvinceCodeNavigation).Where(a => a.UserId == order.UserId && a.ShippingId == order.ShippingId).FirstOrDefault();
            foreach (OrderItem item in Input.orderItems)
            {
                Input.subTotal += (double)(item.Game.Price * item.Quantity);
            }
            Input.finalTotal = (Input.subTotal * (1 + Input.taxRate));
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                TempData["message"] = $"Order Id missing or invalid.";
                return RedirectToAction("Index", "Home");
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["message"] = $"Unable to load user with ID '{_userManager.GetUserId(User)}'.";
                return RedirectToAction("Index", "Home");
            }
            var order = _context.Order.Include(a => a.User).Where(a => a.Id.ToString() == Input.Id.ToString()).FirstOrDefault();
            order.IsShipped = true;
            _context.Update(order);
            await _context.SaveChangesAsync();
            await FillInputModel(id, user);
            StatusMessage = "Order marked as Processed!";
            return Page();
        }
    }
}
