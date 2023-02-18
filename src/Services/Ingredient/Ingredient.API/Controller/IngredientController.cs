using Microsoft.AspNetCore.Mvc;
using Ingredient.API.Repositories;
using Ingredient.API.Entity;
using System.Net;

namespace Ingredient.API.Controller
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class IngredientController : ControllerBase
    {

        private readonly IIngredientRepository _repository;
        private readonly ILogger<IngredientController> _logger;

        public IngredientController(IIngredientRepository repository, ILogger<IngredientController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<IngredientNeed>), (int)HttpStatusCode.OK)]        
        public async Task<ActionResult<List<IngredientNeed>>> GetIngredients()
        {
            var Ingredients = await _repository.GetIngredientsAsync();

            return Ok(Ingredients);
        }

        [HttpGet("{id:length(24)}",Name = "GetIngredient")]
        [ProducesResponseType(typeof(IngredientNeed), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IngredientNeed>> GetIngredient(string id)
        {
            var Ingredients = await _repository.GetIngredientAsync(id);
            if (Ingredients == null)
            {
                _logger.LogError($"Ingredient with id: {id}, not found.");
                return NotFound();
            }
            return Ok(Ingredients);
        }


        [Route("[action]/{name}", Name = "GetIngredientByName")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IngredientNeed>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<IngredientNeed>>> GetIngredientByName(string name)
        {
            var ingredients = await _repository.GetIngredientByNameAsync(name);
            return Ok(ingredients);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IngredientNeed), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IngredientNeed>> CreateIngredient([FromBody] IngredientNeed ingredient)
        {
            if(ingredient.Id?.Length != 24)
            {
                _logger.LogError($"Can not Create Ingredient. The Id Length Should be 24");
                return BadRequest();
            }
            IngredientNeed? ingredientNeed =await _repository.CreateIngredientAsync(ingredient);
            if (ingredientNeed == null)
            {
                _logger.LogError($"Can not Create Ingredient.");
                return BadRequest();
            }

            return Ok(ingredientNeed);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> UpdateIngredient([FromBody] IngredientNeed ingredient)
        {
            bool success = await _repository.UpdateIngredientAsync(ingredient);
            if (!success)
            {
                _logger.LogError($"Can not Create Ingredient.Ingredient with id: {ingredient.Id}");
                return BadRequest();
            }

            return Ok(success);
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteIngredient")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<bool>> DeleteIngredient(string id)
        {
            bool success = await _repository.DeleteIngredientAsync(id);
            if (!success)
            {
                _logger.LogError($"Can not Delete Ingredient.Ingredient with id: {id}");
                return BadRequest();
            }

            return Ok(success);
        }

    }
}
