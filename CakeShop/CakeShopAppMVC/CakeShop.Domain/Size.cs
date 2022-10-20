

namespace CakeShop.Domain
{
    public class Size
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public Size()
        {

        }

        public Size(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}
