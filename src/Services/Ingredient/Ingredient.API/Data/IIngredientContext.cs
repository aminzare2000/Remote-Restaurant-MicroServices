using MongoDB.Driver;
using Ingredient.API.Entity;

namespace Ingredient.API.Data
{
    public interface IIngredientContext
    {
        IMongoCollection<IngredientNeed> Ingredients { get; }
    }
}
