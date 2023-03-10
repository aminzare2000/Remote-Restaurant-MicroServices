using Discount.API.Entities;
namespace Discount.API.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetCoupon(string ingredientName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string ingredientName);
    }
}
