using System.ComponentModel.DataAnnotations;


namespace CakeShop.ViewModels
{
    public class CakeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public decimal Price { get; set; }
      
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        public string? Ingredients { get; set; }
        public string? Description { get; set; }
    }
}
