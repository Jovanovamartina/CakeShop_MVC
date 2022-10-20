using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
    public class CakeOrderViewModelCheckbox
    {
        public int Id { get; set; }
        public CakeViewModel Cake { get; set; }
        public int CakeId{ get; set; }
        public bool Selected { get; set; }
        public decimal Quantity { get; set; }
        public CartViewModel Cart { get; set; }
        public int CartId { get; set; }
    }
}
