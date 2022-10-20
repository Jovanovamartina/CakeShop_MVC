

namespace CakeShop.Domain
{
    public class Cake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }

        public Cake(string name, decimal price, string image, string ingredients, string description)
        {
            Name = name;
            Price = price;
            Image = image;
            Ingredients = ingredients;
            Description = description;

        }
    }
}

