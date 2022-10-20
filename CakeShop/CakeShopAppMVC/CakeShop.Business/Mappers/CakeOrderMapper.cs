using CakeShop.Domain;
using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Mappers
{
    public static class CakeOrderMapper
    {
        public static CakeOrderViewModel ToViewModel(this CakeOrder cakeOrder)
        {
            return new CakeOrderViewModel
            {
                Id = cakeOrder.Id,
                CakeId = cakeOrder.CakeId,
                Selected = cakeOrder.Selected,
                Quantity = cakeOrder.Quantity,
                CartId = cakeOrder.CartId,
                Cake = cakeOrder.Cake.ToViewModel(),
                Price = cakeOrder.Price
            };
        }
    }
}
