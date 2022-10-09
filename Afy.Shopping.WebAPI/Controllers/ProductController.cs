using Afy.Shopping.BLL.Abstract;
using Afy.Shopping.Model.Entities;
using Afy.Shopping.Model.Entities.Basket;
using Afy.Shopping.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Afy.Shopping.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ProductController : Controller
    {
        readonly IProductManager _manager;
        public ProductController(IProductManager productManager)
        {
            _manager = productManager ?? throw new ArgumentNullException(nameof(productManager));
        }

        /// <summary>
        /// Tüm ürünleri getir
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Başarılı</response> 
        /// <response code="404">Başarısız</response> 
        [HttpGet(Name = "GetAll")]
        [ProducesResponseType(typeof(ResponseDto<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseDto<Product>>> GetAll()
        {
            try
            {
                ResponseDto<Product> response = new();
                ICollection<Product> products = await _manager.GetAll();
                int count = products.Count;
                if (count > 0)
                {
                    response.status = true;
                    response.page = 1;
                    response.pagesize = count;
                    response.totalCount = count;
                    response.totalPage = 1;
                    response.items.AddRange(products);
                }
                else
                {
                    response.status = false;
                    response.message = "Katalogda ürün bulunmamaktadır.";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new ResponseDto<Product>() { status = false, message = ex.Message });
            }
        }

        /// <summary>
        /// Belli sayıda ürün getir
        /// </summary>
        /// <param name="request">Sayfa numarası ve sayfa büyüklüğü parametre olarak gönderilir.</param>
        ///  <remarks>
        /// Örnek İstek:
        ///
        ///     POST /RequestDto
        ///     {
        ///        "page": 1,
        ///        "size": 5
        ///     }
        ///
        /// </remarks>
        /// <returns>Ürün listesi</returns>
        /// <response code="200">Başarılı</response>
        [HttpPost(Name = "GetAll")]
        public async Task<ActionResult<ResponseDto<Product>>> GetAll([FromBody] RequestDto request)
        {
            try
            {
                ResponseDto<Product> response = new();
                if (request.page < 1)
                {
                    response.status = false;
                    response.message = "Sayfa numarası birden küçük olamaz";
                }
                else if (request.size < 1 || request.size >= 1000)
                {
                    response.status = false;
                    response.message = "Sayfa büyüklüğü 1 ile 1000 arasında olmalıdır.";
                }
                else
                {
                    ICollection<Product> products = await _manager.GetAll();
                    int count = products.Count;
                    if (count > 0)
                    {
                        response.status = true;
                        response.page = request.page;
                        response.pagesize = request.size;
                        response.totalCount = count;
                        response.totalPage = Convert.ToInt32(Math.Round(count / (double)request.size, MidpointRounding.ToPositiveInfinity));
                        response.items.AddRange(products.Skip((request.page - 1) * request.size).Take(request.size));
                    }
                    else
                    {
                        response.status = false;
                        response.message = "Katalokta ürün bulunmamaktadır.";
                    }
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new ResponseDto<Product>() { status = false, message = ex.Message });
            }
        }
    }
}
