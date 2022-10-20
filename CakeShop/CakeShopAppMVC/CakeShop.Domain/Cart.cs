

namespace CakeShop.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal FullPrice { get; set; }
        public ICollection<CakeOrder> CakeOrders { get; set; }
      
        public Cart(List<CakeOrder>cakeOrders)
        {
            CakeOrders = cakeOrders;
        }

        public Cart()
        {
        }
    }
}
