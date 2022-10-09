using Afy.Shopping.WebMVC.Models;
using Afy.Shopping.WebMVC.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Afy.Shopping.WebMVC.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        IConfiguration _config;
        string apiLink;
        public BasketController(IConfiguration configuration)
        {
            _config = configuration;
            apiLink = _config.GetValue<string>("APILink");
        }
        public IActionResult Index()
        {
            string? username = HttpContext.User.Identity?.Name;
            BasketVM response = ApiJsonHelper.GetEntity<BasketVM>($"{apiLink}basket/getbasket/{username}") ?? null!;
            return View(response);
        }

        public IActionResult AddCart(string id)
        {
            string? username = HttpContext.User.Identity?.Name;
            BasketVM response = ApiJsonHelper.GetEntity<BasketVM>($"{apiLink}basket/getbasket/{username}") ?? null!;
            if (response != null && response.Items != null && response.Items.Count > 0)
            {
                if (response.Items.Any(x => x.ProductId == id))
                {
                    CartItem cartItem = response.Items.Where(x => x.ProductId == id).Single();
                    cartItem.Quantity++;
                }
                else
                {
                    ProductVM product = ApiJsonHelper.GetEntity<ProductVM>($"{apiLink}product/Get/{id}") ?? null!;
                    response.Items.Add(new CartItem()
                    {
                        Price = product.price,
                        ProductId = product.Id,
                        ProductName = product.title,
                        Quantity = 1
                    });
                }
            }
            else
            {
                ProductVM product = ApiJsonHelper.GetEntity<ProductVM>($"{apiLink}product/Get/{id}") ?? null!;
                response = new()
                {
                    UserName = username
                };
                response.Items = new();
                response.Items.Add(new CartItem()
                {
                    Price = product.price,
                    ProductId = product.Id,
                    ProductName = product.title,
                    Quantity = 1
                });
            }
            BasketVM? postResponse = ApiJsonHelper.PostEntity<BasketVM, BasketVM>($"{apiLink}basket/UpdateBasket", response);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult DeleteCartItem(string id, string returnUrl = "Product")
        {
            string? username = HttpContext.User.Identity?.Name;
            BasketVM response = ApiJsonHelper.GetEntity<BasketVM>($"{apiLink}basket/getbasket/{username}") ?? null!;
            if (response != null && response.Items != null && response.Items.Count > 0)
            {
                if (response.Items.Any(x => x.ProductId == id))
                {
                    CartItem cartItem = response.Items.Where(x => x.ProductId == id).Single();
                    response.Items.Remove(cartItem);
                    if (response.Items.Count > 0)
                    {
                        BasketVM? postResponse = ApiJsonHelper.PostEntity<BasketVM, BasketVM>(apiLink + "basket/UpdateBasket", response);
                    }
                    else
                    {
                        ApiJsonHelper.DeleteEntity($"{apiLink}basket/DeleteBasket/{username}");
                    }
                }
            }
            return RedirectToAction("Index", returnUrl);
        }
    }
}
