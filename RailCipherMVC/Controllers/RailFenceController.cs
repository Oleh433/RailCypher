using Microsoft.AspNetCore.Mvc;
using RailCipherMVC.Models;
using RailCipherMVC.Services;

namespace RailCipherMVC.Controllers
{

    public class RailFenceController : Controller
    {
        [HttpGet]
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
                return RedirectToAction("Login", "Auth");

            return View(new RailFenceModel());
        }

        [HttpPost]
        public IActionResult Index(RailFenceModel model)
        {
            if (HttpContext.Session.GetString("IsAuthenticated") != "true")
                return RedirectToAction("Login", "Auth");

            if (string.IsNullOrWhiteSpace(model.InputText))
                return View(model);

            char[,] fence;
            model.EncryptedText = RailFenceCipher.Encrypt(model.InputText, model.Rails, out fence);
            model.DecryptedText = RailFenceCipher.Decrypt(model.EncryptedText, model.Rails);
            model.FenceArray = fence;

            return View(model);
        }

    }
}
