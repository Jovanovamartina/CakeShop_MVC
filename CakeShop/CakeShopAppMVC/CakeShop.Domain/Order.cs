
namespace CakeShop.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsDelivered { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
      


        public Order(string name, string lastName, string address, bool isDelivered, int locationId, int cartId, decimal totalPrice)
        {

            Name = name;
            LastName = lastName;
            Address = address;
            IsDelivered = isDelivered;
            LocationId = locationId;
            CartId = cartId;
            TotalPrice = totalPrice;
        }

        public Order()
        {
        }
    }
}
