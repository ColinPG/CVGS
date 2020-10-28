using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVGS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVGS.Controllers
{
    [Authorize(Roles = "administrators")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        // Initializes the controller.
        public RoleController(RoleManager<IdentityRole> roleManager,
                                        UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }


        // Index: The default action for this controller.
        // Displays a list of roles ordered by name.
        [HttpGet]
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles.OrderBy(m => m.Name));
        }

        //POST CreateRole: Processes a form from the index action, attempting to create a new role.
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (roleName != null)
                roleName = roleName.Trim();
            if (roleName == null || roleName == "")
            {
                TempData["message"] = "Role Name must not be blank.";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = roleName };

                var result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    TempData["message"] = $"role added: {roleName}.";
                    return RedirectToAction("Index");
                }
                else if (await roleManager.RoleExistsAsync(roleName))
                {
                    TempData["message"] = $"{roleName} already exists as a role.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = result.Errors.First().Description;
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        //ListUsersInRole: An action that shows a list of all the users in a selected role id. If no role id is passed 
        //as a parameter, user is sent back to the index. Allows the user to add or remove users from the role.
        [HttpGet]
        public async Task<IActionResult> ListUsersInRole(string id)
        {
            ViewBag.roleId = id;

            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                //No role for id
                TempData["message"] = $"Role with id = {id} cannot be found.";
                var roles = roleManager.Roles;
                return View("Index", roles);
            }
            else
            {
                ViewBag.roleName = role.Name;
            }

            var model = new List<UserViewModel>();
            foreach (var user in userManager.Users)
            {
                var userViewModel = new UserViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                    userViewModel.IsInRole = true;
                else
                    userViewModel.IsInRole = false;

                model.Add(userViewModel);
            }

            return View(model.OrderBy(m => m.UserName));
        }

        //CreateUserRole: Processes a request from the ListUsersInRole page, attempting to assign a selected user
        //to a role.
        [HttpPost]
        public async Task<IActionResult> CreateUserRole(string userId, string roleId)
        {

            var user = await userManager.FindByIdAsync(userId);
            var role = await roleManager.FindByIdAsync(roleId);
            IdentityResult result = null;

            result = await userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                TempData["message"] = $"{user.UserName} added to {role.Name}.";
            }
            else
            {
                // Error
                TempData["message"] = result.Errors.First().Description;
            }
            return RedirectToAction(actionName: "ListUsersInRole", new { id = role.Id });
        }

        //RemoveUserRole: Processes a request from the ListUsersInRole page, attempting to remove a selected user
        //from a role.
        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string userId, string roleId)
        {

            var user = await userManager.FindByIdAsync(userId);
            var role = await roleManager.FindByIdAsync(roleId);
            IdentityResult result = null;

            if (User.Identity.Name == user.UserName && role.Name == "administrators")
            {
                TempData["message"] = $"Can not remove current uesr from administrators role.";
                return RedirectToAction(actionName: "ListUsersInRole", new { id = role.Id });
            }
            result = await userManager.RemoveFromRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                TempData["message"] = $"{user.UserName} removed from {role.Name}.";
            }
            else
            {
                // Error
                TempData["message"] = result.Errors.First().Description;
            }
            return RedirectToAction(actionName: "ListUsersInRole", new { id = role.Id });
        }

        //DeleteRole: Processes a request from the Index page, attempting to delete a role. If the role has no users, it is 
        //deleted instantly. If users are assigned to the role, a confirmation page is displayed, asking if the user is sure if 
        //they want to delete the role.
        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData["message"] = $"Role not found.";
                return RedirectToAction("Index");
            }
            else
            {
                if (role.Name == "administrators")
                {
                    TempData["message"] = $"administrators can not be deleted.";
                    return RedirectToAction("Index");
                }
                var numberOfUsersInRole = await userManager.GetUsersInRoleAsync(role.Name);
                if (numberOfUsersInRole.Count == 0)
                {
                    //If no users, just delete the role.
                    var result = await roleManager.DeleteAsync(role);

                    if (result.Succeeded)
                    {
                        TempData["message"] = $"{role.Name} was deleted.";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["message"] = result.Errors.First().Description;
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.roleId = id;
                    ViewBag.roleName = role.Name;

                    var model = new List<UserViewModel>();
                    foreach (var user in userManager.Users)
                    {
                        var userViewModel = new UserViewModel
                        {
                            UserId = user.Id,
                            UserName = user.UserName
                        };

                        if (await userManager.IsInRoleAsync(user, role.Name))
                            userViewModel.IsInRole = true;
                        else
                            userViewModel.IsInRole = false;

                        model.Add(userViewModel);
                    }

                    return View(model);
                }
            }
        }

        //POST DeleteRolePost: Processes a request from the DeleteRole page, confirming the user wants to delete a role
        //that has users assigned to the role.
        [HttpPost]
        public async Task<IActionResult> DeleteRolePost(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData["message"] = $"Role not found.";
                return RedirectToAction("Index");
            }
            else
            {
                if (role.Name == "administrators")
                {
                    TempData["message"] = $"administrators can not be deleted.";
                    return RedirectToAction("Index");
                }
                //If not admin, just delete the role.
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    TempData["message"] = $"{role.Name} was deleted.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = result.Errors.First().Description;
                    return RedirectToAction("Index");
                }
            }
        }
    }
}