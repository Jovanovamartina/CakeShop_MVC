using CakeShop.Business.Abstraction;
using CakeShop.Business.Mappers;
using CakeShop.DataAccess.Abstraction;
using CakeShop.Domain;
using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Implementation
{

    public class CartService : ICartService
    {
        private readonly ICakeService _cakeService;
        private readonly IRepository<Cake> _cakeRepository;
        private readonly IRepository<Cart> _cartRepository;
        public CartService(ICakeService cakeService, IRepository<Cake> cakeRepository, IRepository<Cart> cartRepository)
        {
            _cakeService = cakeService;
            _cakeRepository = cakeRepository;
            _cartRepository = cartRepository;
        }
        public int Add(CartViewModel cartModel)
        {
            List<CakeOrder> cakeOrders = GetCakeOrders(cartModel.CakeOrderCheckbox.Where(x => x.Selected).ToList());
            foreach (var item in cartModel.CakeOrders)
            {
                CakeOrder order = new CakeOrder()
                {
                    Cake = _cakeRepository.GetEntity(item.CakeId),
                    CakeId = item.CakeId,
                    Quantity = item.Quantity,
                    Selected = item.Selected
                };
                order.Price = order.Cake.Price * order.Quantity;
                cakeOrders.Add(order);
            }
           
                Cart cart = new Cart()
                {
                   CakeOrders = cakeOrders
                };
                _cartRepository.Add(cart);
                cart.FullPrice = cakeOrders.Select(x => x.Price).Sum();
                return cart.Id;
        }

        private List<CakeOrder> GetCakeOrders(List<CakeOrderViewModelCheckbox> cakeModelOrders)
        {
            List<CakeOrder> cakeOrders = new List<CakeOrder>();
            foreach (var item in cakeModelOrders)
            {
                CakeOrder cakeOrder = new CakeOrder()
                {
                    Cake = _cakeRepository.GetEntity(item.CakeId),
                    CakeId = item.CakeId,
                    Quantity = item.Quantity,
                    Selected = item.Selected,
                };
                cakeOrder.Price = cakeOrder.Cake.Price * cakeOrder.Quantity;
                cakeOrders.Add(cakeOrder);
            }
            return cakeOrders;
        }

        public void Delete(int id)
        {
            Cart cart = _cartRepository.GetEntity(id);
            _cartRepository.Delete(cart);
        }

        public List<CartViewModel> GetAllCarts()
        {
            return _cartRepository.GetAll().Select(cart => cart.ToViewModel()).ToList();
        }

        public CartViewModel GetCart(int id)
        {
            return _cartRepository.GetEntity(id).ToViewModel();
        }
    }
}