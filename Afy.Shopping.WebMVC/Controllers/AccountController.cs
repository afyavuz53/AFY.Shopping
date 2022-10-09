using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Afy.Shopping.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            if (HttpContext.User.Identity?.IsAuthenticated ?? false)
                return RedirectToAction("Index", "Product");
            return View();
        }

        [HttpPost]
        public IActionResult LoginUser(string userName)
        {
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,userName??string.Empty),
                    new Claim(ClaimTypes.Role,"customer")
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Product");
        }

        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
