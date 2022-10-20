using CakeShop.DataAccess.Abstraction;
using CakeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.DataAccess.Implementation
{
    public class LocationRepository : IRepository<Location>
    {
        private readonly CakeDbContext _dbContext;

        public LocationRepository(CakeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Location entity)
        {
            _dbContext.Locations.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Location entity)
        {
            _dbContext.Locations.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Location> GetAll()
        {
            return _dbContext.Locations.ToList();
        }

        public Location GetEntity(int? id)
        {
            return _dbContext.Locations.SingleOrDefault(order => order.Id == id);
        }

      

        public void Update(Location entity)
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
