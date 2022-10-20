using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Abstraction
{
    public interface ICartService
    {
        CartViewModel GetCart(int id);
        List<CartViewModel> GetAllCarts();
        void Delete(int id);
        int Add(CartViewModel cart);
    }
}
