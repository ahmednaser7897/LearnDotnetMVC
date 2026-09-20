using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCIdentityAuthentication.Models;
using MVCIdentityAuthentication.ViewModel;

namespace MVCIdentityAuthentication.Controllers;


public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View("Register");
    }
    [HttpPost]
    public async Task<IActionResult> SaveRegister(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            //Mping data 
            var user = new ApplicationUser
            {
                UserName = registerViewModel.UserName,
                Address = registerViewModel.Address,

            };
            //this will save the password with no hashing
            //var ruselt = await _userManager.CreateAsync(user);
            //no with this overloading save the password with hashing
            //save to data base
            var ruselt = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (ruselt.Succeeded)
            {
                // add role 
                await _userManager.AddToRoleAsync(user, "Admin");
                //add cookies 
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Login", "Account");
            }
            foreach (var error in ruselt.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return View("Register", registerViewModel);
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    //request verification token -> to prevent cross site scripting attack 
    // can apply on [HttpPost], [HttpPut], [HttpDelete], [HttpPatch]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveLogin(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            //check if user is exist or not
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                bool found = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (found)
                {
                    //SignIn and add basic cookies (name,id,role)
                    //await _signInManager.SignInAsync(user, loginViewModel.RememberMe);
                    //with AddCookie() we can add custom cookies (name,value,expire)
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim("Address", user.Address??""),
                        //new Claim(ClaimTypes.Email, user.Email),
                        //new Claim(ClaimTypes.Role, "Admin"),
                    };
                    await _signInManager.SignInWithClaimsAsync(user, loginViewModel.RememberMe, claims);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
        }
        return View("Login", loginViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    //https://localhost:7128/Account/TestAuth
    //[Authorize]
    public async Task<IActionResult> TestAuth()
    {
        //User is a property of ControllerBase class
        // that returns an object that represents the current user
        //ClaimsIdentity is an implementation of IPrincipal interface
        //ClaimsPrincipal contains
        if (User.Identity!.IsAuthenticated)
        {
            //this is the base claim types
            //we can add other claim types to the user
            //the types of claims are:
            //NameIdentifier : the id of the user
            //Name : the name of the user
            //Role : the role of the user

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var address = User.Claims.FirstOrDefault(c => c.Type == "Address")?.Value;
            string? name = User.Identity!.Name;
            return Content("Hello " + name + "\nyour id is " + userId + "\nyour role is " + role + "\nyour address is " + address);
        }
        return Content("You are not logged in");
    }

}
