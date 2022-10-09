using Afy.Shopping.WebMVC.Models;
using Afy.Shopping.WebMVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Afy.Shopping.WebMVC.ViewComponents.Basket
{
    public class BasketViewComponent : ViewComponent
    {
        IConfiguration _config;
        string apiLink;
        public BasketViewComponent(IConfiguration configuration)
        {
            _config = configuration;
            apiLink = _config.GetValue<string>("APILink");
        }
        public ViewViewComponentResult Invoke()
        {
            if (HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                string? username = HttpContext.User.Identity.Name;
                BasketVM response = ApiJsonHelper.GetEntity<BasketVM>($"http://localhost:5050/api/v1/basket/getbasket/{username}") ?? null!;
                return View(response);
            }
            else
                return View("EmptyBasket");
        }
    }
}
