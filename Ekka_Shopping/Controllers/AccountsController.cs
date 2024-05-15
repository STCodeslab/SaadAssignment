using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using Ekka_Shopping.Models;
using Ekka_Shopping.Data;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;

public class AccountController : Controller
{
    private readonly EkkaContext _db;
    private readonly IAccountsRepository _accountService;

    public AccountController(EkkaContext db, IAccountsRepository accountService)
    {
        _db = db;
        _accountService = accountService;
    }


    public IActionResult Login()
    {

        return View();

    }

    [HttpPost]
    public async Task<IActionResult> Login(User data)
    {
        var user = await _accountService.GetUserForLoginAsync(data.UserEmail, data.UserPassword);
        if (user != null)
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, user.UserFullName),
            new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            TempData["LoginSuccess"] = "Login successful! Welcome, " + user.UserFullName;

            if (user.RoleId == 1)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (user.RoleId == 3)
            {
                return RedirectToAction("Index", "Home");
            }

            // You can add more role checks if needed.
            return RedirectToAction("Index", "Home"); // Default redirection
        }

        TempData["LoginError"] = "Invalid Email or Password";
        return RedirectToAction("Login"); // Redirect back to the login page
    }




    public IActionResult SignUp() {

        return View();
    
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(User data)
    {
        var signUpSuccess = await _accountService.SignUpAsync(data);
        if (signUpSuccess)
        {
            TempData["SignUpSuccess"] = "SignUp Successfull You can Login Now";

            return RedirectToAction("Account", "Login"); // Redirect to home page upon successful signup
        }

        TempData["SignUpError"] = "Error occurred during signup. Please try again.";
        return View();
    }


    // Utility method to hash password
    public string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }


    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        TempData["LoginSuccess"] = "Logout Successful!";
        return RedirectToAction("Login", "Account");
    }


}
