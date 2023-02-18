using Ingredient.API.Entity;
using Ingredient.API.Data;
using MongoDB.Driver;

//https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
namespace Ingredient.API.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IIngredientContext _context;

        public IngredientRepository(IIngredientContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<IngredientNeed>?> GetIngredientsAsync() =>
            await _context.Ingredients.Find(_ => true).ToListAsync();

        public async Task<IngredientNeed?> GetIngredientAsync(string id) =>
            await _context.Ingredients.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<List<IngredientNeed>?> GetIngredientByNameAsync(string name) =>
            await _context.Ingredients.Find(p => p.Name == name).ToListAsync();

        public async Task<List<IngredientNeed>?> GetIngredientByCategoryNameAsync(string categoryName) =>
            await _context.Ingredients.Find(p => p.CategoryName == categoryName).ToListAsync();

        public async Task<IngredientNeed?> CreateIngredientAsync(IngredientNeed ingredient)
        {

            await _context.Ingredients.InsertOneAsync(ingredient);
            return await GetIngredientAsync(ingredient?.Id ?? String.Empty);
        }

        public async Task<bool> UpdateIngredientAsync(IngredientNeed ingredient)
        {
            var updateResult = await _context.Ingredients.ReplaceOneAsync(filter: g => g.Id == ingredient.Id ,replacement: ingredient);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount>0;
        }

        public async Task<bool> DeleteIngredientAsync(string id)
        {
            FilterDefinition<IngredientNeed> filterDefinition = Builders<IngredientNeed>.Filter.Eq(p=>p.Id, id);    

            var deleteResult = await _context.Ingredients.DeleteOneAsync(filterDefinition);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount>0;
        }

    }
}
