using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ingredient.API.Entity
{
    public class IngredientNeed
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImageFile { get; set; } = string.Empty;
    }
}
