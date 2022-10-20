using CakeShop.Domain;
using CakeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Business.Mappers
{
    public static class CakeMapper
    {
        public static CakeViewModel ToViewModel(this Cake cake)
        {
            return new CakeViewModel
            {
                Id = cake.Id,
                Name = cake.Name,
                Price = cake.Price,
                Image = cake.Image,
                Ingredients = cake.Ingredients,
                Description =cake.Description

            };
        }
    }
}
