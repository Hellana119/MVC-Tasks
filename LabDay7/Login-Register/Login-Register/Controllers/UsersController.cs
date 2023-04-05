using Login_Register.Database.Models;
using Login_Register.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Login_Register.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<CustomUser> _userManager;
    private readonly SignInManager<CustomUser> _signInManager;

    public UsersController(UserManager<CustomUser> userManager,
        SignInManager<CustomUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    #region Register
    [HttpGet]
    public IActionResult Register()
    {
         return View(); 
    }    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = new CustomUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            DateOfBirth = registerDto.DOB
        };
        var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
        if(!creationResult.Succeeded) {
            ModelState.AddModelError(string.Empty, creationResult.Errors.First().Description);
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, "User"),
        };

        await _userManager.AddClaimsAsync(user, claims);
         return RedirectToAction("Login"); 
    }
    #endregion

    #region Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    } 
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto credentials)
    {
        var user = await _userManager.FindByNameAsync(credentials.UserName);
        if(user is null) {
            return View();
        }
        var isAuthenticated = await _userManager.CheckPasswordAsync(user, credentials.Password);
        if (!isAuthenticated)
        {
            return View();
        }
        await _signInManager.SignInAsync(user, true);
        return RedirectToAction("Index", "Home");
    }
    #endregion

    #region Logout
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    #endregion
}
