using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCIdentityAuthentication.Models;
using MVCIdentityAuthentication.ViewModel;

namespace MVCIdentityAuthentication.Controllers;
//we use this to ensure that the user is authorized and its role is admin
//to access this controller or action method
[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    //https://localhost:7128/Role/AddRole
    [HttpGet]
    public IActionResult AddRole()
    {
        return View("AddRole");
    }
    //https://localhost:7128/Role/SaveAddRole
    [HttpPost]
    public async Task<IActionResult> SaveAddRole(RoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            var role = new IdentityRole
            {
                Name = model.RoleName
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return View("AddRole");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return View("AddRole", model);



    }
}

