using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoginDemo.Models;

namespace LoginDemo.Controllers
{
    public class AccountController : Controller
    {
        private const string UsernameCookie = "username";
        private static readonly User ValidUser = new User { Username = "admin", Password = "password" };

        [HttpGet]
        public IActionResult Login(string errorMessage = "")
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != ValidUser.Username)
            {
                return RedirectToAction("Login", new { errorMessage = "Користувач не існує" });
            }
            if (password != ValidUser.Password)
            {
                return RedirectToAction("Login", new { errorMessage = "Пароль не вірний" });
            }

            // кукі з ім'ям користувача
            Response.Cookies.Append(UsernameCookie, username, new CookieOptions { HttpOnly = true });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // Видаляємо кукі
            Response.Cookies.Delete(UsernameCookie);
            return RedirectToAction("Login");
        }
    }
}
