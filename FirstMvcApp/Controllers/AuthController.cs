using FirstMvcApp.Database;
using FirstMvcApp.Models;
using FirstMvcApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FirstMvcApp.Services
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                ClaimsPrincipal claimsPrincipal = _authService.Login(model.Email, model.Password);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            catch (NotFoundException)
            {
                return View();
            }
            //catch (BannedException)
            //{
                
            //}
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register(RegistrationModel model)
        //{
        //    if (_context.Users.Any(u => u.Email == model.Email))
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }

        //    _context.Users.Add(new User 
        //    { 
        //        Name = model.Name, 
        //        Email = model.Email, 
        //        Age = model.Age, 
        //        Password = model.Password
        //    });

        //    _context.SaveChanges();

        //    return View();
        //}
    }
}
