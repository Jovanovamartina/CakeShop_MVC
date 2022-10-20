using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.ViewModels
{
   public class CartViewModel
    {
        public int Id { get; set; }
        public List<CakeOrderViewModel> CakeOrders { get; set; }
        public List<CakeOrderViewModelCheckbox> CakeOrderCheckbox { get; set; }
        public decimal FullPrice { get; set; }
    }
}
