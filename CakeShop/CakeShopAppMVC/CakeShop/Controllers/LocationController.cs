using CakeShop.Business.Abstraction;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IActionResult Index()
        {
            return View(_locationService.GetAll());
        }
        public IActionResult EditOrAddLocation(int? id)
        {
            if (id.HasValue)
            {
                LocationViewModel location = _locationService.GetLocation(id);
                return View(location);
            }
            else
            {
                return View(new LocationViewModel());
            }

        }
        [HttpPost]
        public IActionResult EditOrAddLocation(LocationViewModel model)
        {
            if (model.Name != null && model.Address != null)
            {
                if (model.Id == 0)
                {
                    _locationService.Add(model);
                    return RedirectToAction("Index", "Location");
                }
                else
                {
                    _locationService.Update(model);
                }
                return RedirectToAction("Index", "Location");
            }
            else
            {
                return View(model);
            }


        }
        public IActionResult DeleteLocation(int id)
        {
            LocationViewModel location = _locationService.GetLocation(id);
            _locationService.Delete(location.Id);
            return RedirectToAction("Index", "Location");
        }
        public IActionResult Search(string id)
        {

            if (string.IsNullOrEmpty(id) || !_locationService.GetAll().Any(x => x.Name.ToLower().Contains(id.ToLower())))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(_locationService.GetAll().Where(cake => cake.Name.ToLower().Contains(id.ToLower())).ToList());
            }
        }
    }
}
