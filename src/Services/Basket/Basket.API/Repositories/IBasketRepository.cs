using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketBuy?> GetBasket(string username);
        Task<BasketBuy> UpdateBasket(BasketBuy basket);
        Task DeleteBasket(string username);
    }
}
