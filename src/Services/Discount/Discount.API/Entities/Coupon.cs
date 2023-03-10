namespace Discount.API.Entities
{
    public class Coupon
    {
        public Coupon()
        { Ingredientname = "No Discount"; Amount = 0; Description = "No Discount Desc"; }
        public int Id { get; set; }
        public string Ingredientname { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}