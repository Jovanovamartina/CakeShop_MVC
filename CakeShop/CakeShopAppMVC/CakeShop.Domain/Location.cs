

namespace CakeShop.Domain
{
   public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public DateTime OpenAt { get; set; }
        public DateTime CloseAt { get; set; }
        public Location()
        {

        }
        public Location(string name,string address,DateTime openAt,DateTime closeAt)
        {
            Name = name;
            Address = address;
            OpenAt = openAt;
            CloseAt = closeAt;
            Image = "https://images.creativemarket.com/0.1.0/ps/797108/2000/1500/m1/fpnw/wm0/cake-shop-logo-mock-up-1-.jpg?1448176497&s=57e541bc392c59d6b6c6097b57105505";
        }
      
    }
}
