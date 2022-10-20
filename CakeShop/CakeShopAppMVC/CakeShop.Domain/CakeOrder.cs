

namespace CakeShop.Domain
{
    public class CakeOrder
    {
        public int Id { get; set; }
        public int CakeId { get; set; }
        public Cake Cake { get; set; }
        public bool Selected { get; set; }
        public decimal Quantity { get; set; }
        public Cart Cart { get; set; }
        public int CartId { get; set; }
        public decimal Price { get; set; }
       
        public CakeOrder(int cakeId,decimal quantity)
        {
            CakeId = cakeId;
            Quantity = quantity;
        }

        public CakeOrder()
        {
        }
    }
}
