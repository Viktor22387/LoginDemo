using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers
{
    public class HomeController : Controller
    {
        private const string UsernameCookie = "username";

        public IActionResult Index()
        {
            // Перевірка наявності кукі
            if (!Request.Cookies.ContainsKey(UsernameCookie))
            {
                return RedirectToAction("Login", "Account");
            }

            string username = Request.Cookies[UsernameCookie];
            ViewBag.Username = username;
            return View();
        }
    }
}
