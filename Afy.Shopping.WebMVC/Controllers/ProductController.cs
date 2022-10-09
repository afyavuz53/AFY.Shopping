using Afy.Shopping.WebMVC.Models;
using Afy.Shopping.WebMVC.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Afy.Shopping.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IConfiguration _config;
        string apiLink;
        public ProductController(IConfiguration configuration)
        {
            _config = configuration;
            apiLink = _config.GetValue<string>("APILink");
        }
        public IActionResult Index()
        {
            ResponseAPIDto<ProductVM> response = ApiJsonHelper.GetEntity<ResponseAPIDto<ProductVM>>(apiLink + "product/getall") ?? null!;
            return View(response.items);
        }
    }
}
