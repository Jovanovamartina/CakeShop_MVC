using CakeShop.DataAccess.Abstraction;
using CakeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.DataAccess.Implementation
{
    public class CakeRepository : IRepository<Cake>
    {
        private readonly CakeDbContext _dbContext;

        public CakeRepository(CakeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Cake entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Cake entity)
        {
            _dbContext.Cakes.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Cake> GetAll()
        {
            return _dbContext.Cakes.ToList();
        }

        public Cake GetEntity(int? id)
        {

            return _dbContext.Cakes.SingleOrDefault(order => order.Id == id);

        }

        

        public void Update(Cake entity)
        {
            var item = GetEntity(entity.Id);
            if (item != null)
            {
                _dbContext.Entry(item).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
            }
        }
    }
}
