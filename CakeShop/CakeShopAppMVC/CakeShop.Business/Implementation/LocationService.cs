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
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepository;
        public LocationService(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public void Add(LocationViewModel viewModel)
        {
            Location location = new Location(viewModel.Name, viewModel.Address, viewModel.OpenAt, viewModel.CloseAt);

            _locationRepository.Add(location);
        }

        public void Delete(int? id)
        {
            _locationRepository.Delete(_locationRepository.GetEntity(id));
        }

        public List<LocationViewModel> GetAll()
        {
            return _locationRepository.GetAll().Select(location => location.ToViewModel()).ToList();
        }

        public LocationViewModel GetLocation(int? id)
        {
            return _locationRepository.GetEntity(id).ToViewModel();
        }

        public void Update(LocationViewModel viewModel)
        {
            Location location = new Location(viewModel.Name, viewModel.Address, viewModel.OpenAt, viewModel.CloseAt) { Id = viewModel.Id };
            _locationRepository.Update(location);
        }
    }
}
