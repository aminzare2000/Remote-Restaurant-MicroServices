using Ingredient.API.Entity;

namespace Ingredient.API.Repositories
{
    public interface IIngredientRepository
    {
        Task<List<IngredientNeed>?> GetIngredientsAsync();
        Task<IngredientNeed?> GetIngredientAsync(string id);
        Task<List<IngredientNeed>?> GetIngredientByNameAsync(string name);
        Task<List<IngredientNeed>?> GetIngredientByCategoryNameAsync(string categoryName);

        Task<IngredientNeed?> CreateIngredientAsync(IngredientNeed ingredient);
        Task<bool> UpdateIngredientAsync(IngredientNeed ingredient);
        Task<bool> DeleteIngredientAsync(string id);
    }
}
