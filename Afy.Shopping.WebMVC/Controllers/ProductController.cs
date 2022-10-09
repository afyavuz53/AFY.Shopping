using Afy.Shopping.WebMVC.Models;
using Afy.Shopping.WebMVC.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Afy.Shopping.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ResponseAPIDto<ProductVM> response = ApiJsonHelper.GetEntity<ResponseAPIDto<ProductVM>>("http://localhost:5050/api/v1/product/getall") ?? null!;
            return View(response.items);
        }
    }
}
