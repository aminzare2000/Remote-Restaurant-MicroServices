using Microsoft.AspNetCore.Mvc;
using Discount.API.Repositories;
using Discount.API.Entities;
using System.Net;

namespace Discount.API.Controller
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
        }


        [HttpGet(template: "{ingredientName}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> GetDiscount(string ingredientName)
        {
            var discount = await _discountRepository.GetCoupon(ingredientName);
            return Ok(discount);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody] Coupon coupon)
        {
            await _discountRepository.CreateDiscount(coupon);
            var createdResource = new { ingredientName = coupon.Ingredientname};
            var routeValues = new { ingredientName = createdResource.ingredientName};
            return CreatedAtRoute("GetDiscount",routeValues,createdResource);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateDiscount([FromBody] Coupon coupon)
        {
            bool isSucces = await _discountRepository.UpdateDiscount(coupon);
            return Ok(isSucces);
        }

        [HttpDelete(template: "{ingredientName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDiscount(string ingredientName)
        {
            bool isSucces = await _discountRepository.DeleteDiscount(ingredientName);
            return Ok(isSucces);
        }

    }
}
