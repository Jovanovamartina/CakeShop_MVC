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
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly ICartService _cartService;
        private readonly IRepository<Location> _locationRepository;
        private readonly ICakeService _cakeService;
        public OrderService(IRepository<Order> orderRepository, ICartService cartService, IRepository<Location> locationRepository, ICakeService cakeService)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _locationRepository = locationRepository;
            _cakeService = cakeService;
        }
        public void Add(OrderViewModel viewModel)
        {
            Order order = new Order();
            order.Name = viewModel.Name;
            order.LastName = viewModel.LastName;
            order.CartId = viewModel.CartId;
            order.Address = viewModel.Address;
            order.TotalPrice = _cartService.GetCart(viewModel.CartId).FullPrice;
            order.Location = _locationRepository.GetEntity(viewModel.LocationId);
            order.IsDelivered = viewModel.IsDelivered;
            order.Date = viewModel.Date;
            _orderRepository.Add(order);
        }

        public void Delete(int id)
        {
            Order order = _orderRepository.GetEntity(id);
            _orderRepository.Delete(order);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            return _orderRepository.GetAll().Select(order => order.ToViewModel()).ToList();
        }

        public OrderViewModel GetOrder(int id)
        {
            return _orderRepository.GetEntity(id).ToViewModel();
        }

        public CakeOrderViewModel ReturnCakeOrderModel(CakeOrderViewModel model)
        {
            CakeViewModel cakeModel = _cakeService.GetCake(model.CakeId);
            CakeOrderViewModel cakeOrderModel = new CakeOrderViewModel();
            cakeOrderModel.Selected = true;
            cakeOrderModel.CakeId = cakeModel.Id;
            cakeOrderModel.Cake = cakeModel;
            return cakeOrderModel;
        }

        public void Update(OrderViewModel viewModel)
        {
            Order order = new Order(
                viewModel.Name,
                viewModel.LastName,
                viewModel.Address,
                true,
                viewModel.Location.Id,
                viewModel.CartId,
                viewModel.TotalPrice)
            { Id = viewModel.Id };
            _orderRepository.Update(order);
        }
    }
}
