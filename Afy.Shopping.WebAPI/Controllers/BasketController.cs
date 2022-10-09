using Afy.Shopping.BLL.Abstract;
using Afy.Shopping.Model.Entities.Basket;
using Afy.Shopping.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Afy.Shopping.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketManager _basketManager;
        public BasketController(IBasketManager basket)
        {
            _basketManager = basket ?? throw new ArgumentNullException(nameof(basket));
        }

        /// <summary>
        /// Sepeti getir
        /// </summary>
        /// <param name="userName">Kullanıcı adı</param>
        /// <returns></returns>
        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            ShoppingCart basket = await _basketManager.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        /// <summary>
        /// Sepeti güncelle
        /// </summary>
        /// <param name="basket">Sepet</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            return Ok(await _basketManager.UpdateBasket(basket));
        }

        /// <summary>
        /// Sepeti sil
        /// </summary>
        /// <param name="userName">Kullanıcı Adı</param>
        /// <returns></returns>
        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basketManager.DeleteBasket(userName);
            return Ok();
        }
    }
}