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
    public class CakeService : ICakeService
    {
        private readonly IRepository<Cake> _cakeRepository;
        public CakeService(IRepository<Cake> cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }
        public void Add(CakeViewModel viewModel)
        {
            Cake cake = new Cake(
               viewModel.Name,
               viewModel.Price,
               viewModel.Image,
               viewModel.Ingredients == null ? "" : viewModel.Ingredients,
               viewModel.Description == null ? "" : viewModel.Description);
            _cakeRepository.Add(cake);
        }

        public void Delete(int id)
        {
            Cake cake = _cakeRepository.GetEntity(id);
            _cakeRepository.Delete(cake);
        }

        public CakeViewModel Details(CakeViewModel cake)
        {
            CakeViewModel cakeViewModel = GetCake(cake.Id);
            return cakeViewModel;
        }

        public List<CakeViewModel> GetAllCakes()
        {
            return _cakeRepository.GetAll().Select(cake => cake.ToViewModel()).ToList();
        }

        public CakeViewModel GetCake(int? id)
        {
            CakeViewModel? cake = _cakeRepository.GetEntity(id).ToViewModel();
            return cake;
        }



        public List<CakeViewModel> RandomCakes()
        {
            Random rndm = new Random();
            List<CakeViewModel> cakeViewModels = GetAllCakes();
            List<CakeViewModel> cakesToSend = new List<CakeViewModel>();
            for (int i = 0; i < 3; i++)
            {
                int rnd = rndm.Next(1, cakeViewModels.Count);
                CakeViewModel cake = cakeViewModels[rnd];
                if (cakesToSend.Contains(cake))
                {
                    cakesToSend.Remove(cake);
                }
                else
                {
                    cakesToSend.Add(cake);
                }
            }
            return cakesToSend;
        }

        public void Update(CakeViewModel viewModel)
        {
            Cake cake = new Cake(viewModel.Name,
                                        viewModel.Price,
                                        viewModel.Image,
                                        viewModel.Ingredients == null ? "" : viewModel.Ingredients,
                                        viewModel.Description == null ? "" : viewModel.Description)
            {
                Id = viewModel.Id
            };
            _cakeRepository.Update(cake);
        }
    }
}
