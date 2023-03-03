using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<BasketBuy?> GetBasket(string username)
        {
            var basket =await _redisCache.GetStringAsync(username);
            if(string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<BasketBuy>(basket);
        }

        public async Task<BasketBuy> UpdateBasket(BasketBuy basket)
        {
            await _redisCache.SetStringAsync(basket.Username, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.Username)?? throw new ArgumentNullException();
            
        }
        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }
    }
}
