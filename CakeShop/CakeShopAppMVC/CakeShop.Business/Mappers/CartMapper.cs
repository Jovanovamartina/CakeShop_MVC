using CakeShop.Domain;
using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Mappers
{
    public static class CartMapper
    {
        public static CartViewModel ToViewModel(this Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
               CakeOrders = cart.CakeOrders.Select(cake => cake.ToViewModel()).ToList(),
                FullPrice = cart.FullPrice

            };
        }
    }
}
