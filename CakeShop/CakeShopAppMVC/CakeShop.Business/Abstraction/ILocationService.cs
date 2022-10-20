using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Abstraction
{
    public interface ILocationService
    {
        List<LocationViewModel> GetAll();
        LocationViewModel GetLocation(int? id);
        void Add(LocationViewModel viewModel);
        void Delete(int? id);
        void Update(LocationViewModel viewModel);
    }
}
