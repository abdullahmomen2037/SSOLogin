using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        // ✅ Redirect to Google
        [HttpPost]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Home");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, "Google");
        }

        // ✅ Google callback
        public IActionResult GoogleResponse()
        {
            // Get claims from the current user context
            var claims = User.Claims.ToList();
            ViewBag.Email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            ViewBag.Name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return View("Profile");
        }

        // ✅ Logout
        public IActionResult Logout()
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
