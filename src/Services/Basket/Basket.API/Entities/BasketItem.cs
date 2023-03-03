namespace Basket.API.Entities
{
    public class BasketItem
    {
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string IngredientName { get; set; }
        public string IngredientId { get; set; }
    }
}
