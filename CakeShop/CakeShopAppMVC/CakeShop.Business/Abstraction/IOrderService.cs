using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Abstraction
{
    public interface IOrderService
    {
        OrderViewModel GetOrder(int id);
        List<OrderViewModel> GetAllOrders();
       CakeOrderViewModel ReturnCakeOrderModel(CakeOrderViewModel model);
        void Delete(int id);
        void Add(OrderViewModel viewModel);
        void Update(OrderViewModel viewModel);
    }
}
