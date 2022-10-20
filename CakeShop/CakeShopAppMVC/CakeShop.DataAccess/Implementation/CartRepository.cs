using CakeShop.DataAccess.Abstraction;
using CakeShop.Domain;
using Microsoft.EntityFrameworkCore;


namespace CakeShop.DataAccess.Implementation
{
    public class CartRepository : IRepository<Cart>
    {
        private readonly CakeDbContext _dbContext;

        public CartRepository(CakeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Cart entity)
        {
            _dbContext.Carts.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Cart entity)
        {
            _dbContext.Carts.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Cart> GetAll()
        {
            return _dbContext.Carts.
               Include(x => x.CakeOrders).
               ThenInclude(x => x.Cake)
               .ToList();
        }

        public Cart GetEntity(int? id)
        {
            return _dbContext.Carts.
                Include(x => x.CakeOrders).
                ThenInclude(x => x.Cake).
                SingleOrDefault(order => order.Id == id);
        }


        public void Update(Cart entity)
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
