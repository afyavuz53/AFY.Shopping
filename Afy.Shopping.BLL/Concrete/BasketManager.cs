using Afy.Shopping.BLL.Abstract;
using Afy.Shopping.Core.Common.Interfaces;
using Afy.Shopping.Model.Entities.Basket;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.BLL.Concrete
{
    internal class BasketManager : IBasketManager
    {
        private readonly IDistributedCache _redisCache;
        private readonly ISerializerService _serializerService;
        public BasketManager(IDistributedCache cache, ISerializerService serializer)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
            _serializerService = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }
        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (String.IsNullOrEmpty(basket))
                return null!;
            return _serializerService.Deserialize<ShoppingCart>(basket) ?? null!;
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, _serializerService.Serialize(basket));

            return await GetBasket(basket.UserName);
        }
    }
}
