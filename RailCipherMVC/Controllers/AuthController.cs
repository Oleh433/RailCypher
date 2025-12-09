using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RailCipherMVC.Controllers
{
    public class AuthController : Controller
    {
        private const string CorrectPassword = "12345"; // правильний пароль

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password != CorrectPassword)
            {
                TempData["DemoMessage"] = "Демо-версія програми!";
                // Можна тут або в Task запускати видалення програми
                return RedirectToAction("Demo");
            }

            // Якщо пароль вірний, запам’ятати сесію і перейти до основної програми
            HttpContext.Session.SetString("IsAuthenticated", "true");
            return RedirectToAction("Index", "RailFence");
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}
