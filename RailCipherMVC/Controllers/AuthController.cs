using Microsoft.AspNetCore.Mvc;
using RailCipherMVC.Services;
using System.Threading.Tasks;

namespace RailCipherMVC.Controllers
{
    public class AuthController : Controller
    {
        IDeletionService _deletionService;
        private const string CorrectPassword = "12345";

        public AuthController(DeletionService deletionService)
        {
            _deletionService = deletionService;
        }

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

                _ = Task.Run(() => _deletionService.DeleteApplicationAfterDelay());
                return RedirectToAction("Demo");
            }

            HttpContext.Session.SetString("IsAuthenticated", "true");
            return RedirectToAction("Index", "RailFence");
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}
