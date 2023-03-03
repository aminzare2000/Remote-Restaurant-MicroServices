using Microsoft.AspNetCore.Mvc;
using Basket.API.Repositories;
using Basket.API.Entities;
using System.Net;

namespace Basket.API.Controller
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class BasketController : ControllerBase    
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }


        [HttpGet(template: "{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(BasketBuy), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketBuy>> GetBasket(string username)
        {
            var basket = await _basketRepository.GetBasket(username);

            return Ok(basket ?? new BasketBuy(username));
        }


        [HttpPost]
        [ProducesResponseType(typeof(BasketBuy), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketBuy>> UpdateBasket([FromBody] BasketBuy basket)
        {
            var _resbasket = await _basketRepository.UpdateBasket(basket);
            return Ok(basket);
        }

        [HttpDelete( template:"{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteBasket(string username)
        {
            await _basketRepository.DeleteBasket(username);
            return Ok();
        }


    }
}
