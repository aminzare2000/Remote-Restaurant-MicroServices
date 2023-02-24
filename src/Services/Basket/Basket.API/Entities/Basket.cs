namespace Basket.API.Entities
{
    public class Basket
    {
        public string Username { get; set; }
        
        public List<BasketItem> Items { get; set;} = new List<BasketItem>();

        public Basket()
        {

        }

        public Basket(string username)
        {
            Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal price = 0;
                foreach (var item in Items)
                {
                    price += item.Price*item.Weight;
                }

                return price;
            }
        }
    }
}
