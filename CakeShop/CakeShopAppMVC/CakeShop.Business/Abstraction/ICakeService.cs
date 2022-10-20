using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Abstraction
{
    public interface ICakeService
    {
        CakeViewModel GetCake(int? id);
        List<CakeViewModel> GetAllCakes();
        CakeViewModel Details(CakeViewModel cake);
        void Delete(int id);
        void Update(CakeViewModel viewModel);
        void Add(CakeViewModel viewModel);
        List<CakeViewModel> RandomCakes();
    
    }
}
