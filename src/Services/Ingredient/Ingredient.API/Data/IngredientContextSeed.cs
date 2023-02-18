using Ingredient.API.Entity;
using MongoDB.Driver;

namespace Ingredient.API.Data
{
    public class IngredientContextSeed
    {
        public static void SeedData(IMongoCollection<IngredientNeed>? ingredientCollection)
        {
            var cursorCollection = ingredientCollection?.Find(p => true);
            if (!cursorCollection.Any())
            {
                ingredientCollection?.InsertMany(GetPreConfiguredIngredientNeeds());
            }
        }

        private static IEnumerable<IngredientNeed> GetPreConfiguredIngredientNeeds()
        {
            //https://www.cookingwithamc.info/
            return new List<IngredientNeed>()
            {
                new IngredientNeed()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "carrots",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "carrots-1.png",
                    Price = 1M,
                    CategoryName = "Vegetables"
                },
                new IngredientNeed()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "zucchini",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "zucchini-2.png",
                    Price = 12.00M,
                    CategoryName = "Vegetables"
                },
                new IngredientNeed()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "beef",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "beef-3.png",
                    Price = 650.00M,
                    CategoryName = "Meat"
                },
                new IngredientNeed()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "lemon",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "lemon-4.png",
                    Price = 470.00M,
                    CategoryName = "Fruits"
                },
                new IngredientNeed()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Moroccan trout",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "Moroccan-5.png",
                    Price = 380.00M,
                    CategoryName = "Seafood"
                },
                new IngredientNeed()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Rice pudding",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "Ricepudding-6.png",
                    Price = 240.00M,
                    CategoryName = "Dessert"
                }
            };
        }
    }
}

