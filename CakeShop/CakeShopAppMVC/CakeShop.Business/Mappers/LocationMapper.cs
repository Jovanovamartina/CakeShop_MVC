using CakeShop.Domain;
using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Mappers
{
    public static class LocationMapper
    {
        public static LocationViewModel ToViewModel(this Location location)
        {
            return new LocationViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpenAt = location.OpenAt,
                CloseAt = location.CloseAt,
                Image = location.Image
            };
        }
    }
}
