using CakeShop.Business.Abstraction;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeService _cakeService;
        public CakeController(ICakeService cakeService)
        {
            _cakeService = cakeService;
        }
        public IActionResult Index()
        {
            return View(_cakeService.GetAllCakes());
        }
        public IActionResult Details(CakeViewModel model)
        {
            return View(_cakeService.Details(model));
        }
        public IActionResult AddOrEditCakeMenu(int? id)
        {
            if (id.HasValue)
            {
                CakeViewModel? cake = _cakeService.GetCake(id);
                if (cake == null)
                {
                    return RedirectToAction("Index", "Cake");
                }
                else
                {
                    return View(cake);
                }
            }
            return View(new CakeViewModel());
        }
        [HttpPost]
        public IActionResult AddOrEditCakeMenu(CakeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {

                    _cakeService.Add(model);
                    return RedirectToAction("Index", "Cake");
                }
                else
                {
                    _cakeService.Update(model);
                    return RedirectToAction("Index", "Cake");
                }
            }
            else
            {
                return View(model);
            }

        }
        public IActionResult DeleteCake(int id)
        {
            _cakeService.Delete(id);
            return RedirectToAction("Index", "Cake");
        }

        public IActionResult Search(string id)
        {
            if (string.IsNullOrEmpty(id) || !_cakeService.GetAllCakes().Any(cake => cake.Name.ToLower().Contains(id.ToLower())))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(_cakeService.GetAllCakes().Where(cake => cake.Name.ToLower().Contains(id.ToLower())).ToList());
            }
        }
    }
}
