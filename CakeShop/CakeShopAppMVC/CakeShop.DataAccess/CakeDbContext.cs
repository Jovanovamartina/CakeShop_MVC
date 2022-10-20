using CakeShop.Domain;
using Microsoft.EntityFrameworkCore;


namespace CakeShop.DataAccess
{
    public class CakeDbContext : DbContext
    {
        public CakeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<CakeOrder> CakeOrders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Size> Sizes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cake>().ToTable("Cake");
            builder.Entity<Cart>().ToTable("Cart");
            builder.Entity<Location>().ToTable("Location");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<CakeOrder>().ToTable("CakeOrder");
            builder.Entity<Size>().ToTable("Size");

            builder.Entity<Cake>().HasData(
                    new Cake("cheesecake",
                    650,
                    "https://www.thespruceeats.com/thmb/r8TCBwuaBBV5oBKc5vXzP7JvllU=/940x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/gluten-free-new-york-cheesecake-1450985-hero-01-dc54f9daf38044238b495c7cefc191fa.jpg",
                    "Cream cheese, soure cream, eggs,biscuits, sugar, cheery",
                    "Cheesecake is a sweet dessert consisting of one or more layers. The main, and thickest, layer consists of a mixture of a soft, fresh cheese, eggs, and sugar. If there is a bottom layer, it most often consists of a crust or base made from crushed cookies, graham crackers, pastry, or sometimes sponge cake.")
                    {
                        Id = 1
                    },
                    new Cake("Chocolate Cake",
                    700,
                    "https://th.bing.com/th/id/OIP.L8n28h8SNmk_9C8OQxXMqAHaJR?pid=ImgDet&rs=1",
                    "Flour,sugar, Chocolate, eggs, milk,vanilla",
                    "Chocolate cake or chocolate gâteau is a cake flavored with melted chocolate, cocoa powder, or both.Chocolate cake is made with chocolate.It can also include other ingredients.These include fudge, vanilla creme, and other sweeteners.")
                    {
                        Id = 2
                    },
                    new Cake("chocolate mousse cake",
                    350,
                    "https://img.taste.com.au/thf4ZgLa/taste/2016/11/top-50-cakes-image-30-66357-1.jpg",
                    "Chocolate biscuits,Butter,Dark Chocolate,Cream,Coffee",
                    "This mousse cake is our homage to the Canadian favourite, just in time for the holidays. It starts with a bottom layer of cake, and includes cream, in lieu of egg whites, to give the mousse better consistency. ")
                    {
                        Id = 3
                    },
                    new Cake("strawberry Cake",
                    450,
                    "https://img.taste.com.au/GIR51Wnj/taste/2016/11/top-50-cakes-image-31-66359-1.jpg",
                    "coconut,Lemon Juice,Frozen strawberries,flour,Eggs,Sugar,Milk",
                    "A moist and fluffy strawberry cake filled with strawberry and lemon buttercream and crowned with strawberries and buttercream roses")
                    {
                        Id = 4
                    },
                    new Cake(" Raspberry cake",
                    250,
                    "https://img.taste.com.au/-dGYc9Ej/taste/2016/11/top-50-cakes-image-49-66387-1.jpg",
                    "frozen raspberries,Eggs,Sugar,Almonds",
                    "A veggie burger is a hamburger patty that does not contain meat. It may be made from ingredients like beans, " +
                    "A moist and fluffy raspberry cake filled with raspberry and lemon buttercream and crowned with raspberry and buttercream roses")
                    {
                        Id = 5
                    }
                );

            builder.Entity<Location>().HasData(
                    new Location("Cake House", "Kaspos", new DateTime(2022, 1, 1, 8, 00, 00), new DateTime(2022, 1, 1, 23, 00, 00))
                    {
                        Id = 1
                    },
                    new Location("Cake House", "Centar", new DateTime(2022, 1, 1, 8, 00, 00), new DateTime(2022, 1, 1, 23, 00, 00))
                    {
                        Id = 2
                    },
                    new Location("Cake House", "Aerodrom", new DateTime(2022, 1, 1, 8, 00, 00), new DateTime(2022, 1, 1, 23, 00, 00))
                    {
                        Id = 3
                    },
                    new Location("Cake House", "Novo Lisice", new DateTime(2022, 1, 1, 8, 00, 00), new DateTime(2022, 1, 1, 23, 00, 00))
                    {
                        Id = 4
                    },
                    new Location("Cake House", "Avtokomanda", new DateTime(2022, 1, 1, 8, 00, 00), new DateTime(2022, 1, 1, 23, 00, 00))
                    {
                        Id = 5
                    }
                );
            builder.Entity<Size>().HasData(
                    new Size("Quarter", 300)
                    {
                        Id = 1
                    },
                    new Size("Half", 600)
                    {
                        Id = 2
                    },
                    new Size("Full", 900)
                    {
                        Id = 3
                    }
                );

        }
    }
}
