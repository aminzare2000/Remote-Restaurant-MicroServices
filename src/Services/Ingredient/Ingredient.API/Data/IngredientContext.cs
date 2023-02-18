using Ingredient.API.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ingredient.API.Data
{
    public class IngredientContext : IIngredientContext
    {
        public IngredientContext(IOptions<IngredientDatabaseSettings> configuration)
        {
            //var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

                        var client = new MongoClient(configuration.Value.ConnectionString);
            //var client = new MongoClient("mongodb://root:1q2w3e4r@127.0.0.1:27017");

            //var x =client.ListDatabaseNames().Current.ToList();
            var database = client.GetDatabase(configuration.Value.DatabaseName);
            

            Ingredients = database!=null ? database.GetCollection<IngredientNeed>(configuration.Value.CollectionName) :  throw new ArgumentNullException(nameof(database));
            IngredientContextSeed.SeedData(Ingredients);
        }

        public IMongoCollection<IngredientNeed> Ingredients { get;   }
    }
}
