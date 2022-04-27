using FirstMvcApp.Database;
using FirstMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcApp.Controllers
{
    public class AuthController : Controller
    {
        UserDbContext _context;

        public AuthController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                return RedirectToAction("Error", "Home");
            }

            _context.Users.Add(new User 
            { 
                Name = model.Name, 
                Email = model.Email, 
                Age = model.Age, 
                Password = model.Password
            });

            _context.SaveChanges();

            return View();
        }
    }
}
