using CakeShop.Business.Abstraction;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CakeShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICakeService _cakeService;
        private readonly ICartService _cartService;
        private readonly ILocationService _locationService;
        public OrderController(IOrderService orderService,
                               ICakeService cakeService,
                               ICartService cartService,
                               ILocationService locationService)
        {
            _orderService = orderService;
            _cakeService = cakeService;
            _cartService = cartService;
            _locationService = locationService;
        }
        public IActionResult Index()
        {
            ViewBag.Locations = _locationService.GetAll();
            return View(_orderService.GetAllOrders());
        }
        public IActionResult GetCakeOrder(int id)
        {
            return RedirectToAction("CreateCartModel", new CakeOrderViewModel() { CakeId = id });
        }
        public IActionResult CreateCartModel(CakeOrderViewModel model)
        {
            ViewBag.CakeViewModels = _cakeService.GetAllCakes().Where(x => x.Id != model.CakeId).ToList();
            return View(new CartViewModel() {CakeOrders = new List<CakeOrderViewModel>() { _orderService.ReturnCakeOrderModel(model) } });
        }

        [HttpPost]
        public IActionResult AddToCart(CartViewModel model)
        {
            int id = _cartService.Add(model);
            ViewBag.Locations = _locationService.GetAll().Select(item => new SelectListItem(item.Name, item.Id.ToString())).ToList();
            return View(new OrderViewModel() { CartId = id });

        }
        public IActionResult AddToCart(OrderViewModel model)
        {
            ViewBag.Locations = _locationService.GetAll().Select(item => new SelectListItem(item.Name, item.Id.ToString())).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveOrder(OrderViewModel model)
        {
           
                _orderService.Add(model);
                return RedirectToAction("Index", "Order");
            
            

        }
        public IActionResult Details(int id)
        {
            return View(_orderService.GetOrder(id));
        }
        public IActionResult DeleteOrder(int id)
        {
            OrderViewModel order = _orderService.GetOrder(id);
            _cartService.Delete(order.CartId);
            return RedirectToAction("Index", "Order");
        }
        public IActionResult ConfirmDelivery(int id)
        {
            OrderViewModel order = _orderService.GetOrder(id);
            _orderService.Update(order);

            return RedirectToAction("Details", new { id = order.Id });
        }
        public IActionResult Search(string id)
        {
            if (!int.TryParse(id, out int output))
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (_orderService.GetAllOrders().Any(x => x.Id == output))
                {
                    return View(_orderService.GetOrder(output));
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}

