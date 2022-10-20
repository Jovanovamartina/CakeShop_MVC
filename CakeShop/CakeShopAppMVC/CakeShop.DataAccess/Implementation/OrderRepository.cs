using CakeShop.DataAccess.Abstraction;
using CakeShop.Domain;
using Microsoft.EntityFrameworkCore;


namespace CakeShop.DataAccess.Implementation
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly CakeDbContext _dbContext;

        public OrderRepository(CakeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _dbContext.Orders.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.
               Include(x => x.Cart).
               ThenInclude(x => x.CakeOrders).
               ThenInclude(x => x.Cake).
               Include(x => x.Cart).
               Include(x => x.Location).ToList();
        }

        public Order GetEntity(int? id)
        {
            return _dbContext.Orders.
               Include(x => x.Cart).
               ThenInclude(x => x.CakeOrders).
               ThenInclude(x => x.Cake).
               Include(x => x.Cart).
               Include(x => x.Location).SingleOrDefault(order => order.Id == id);
        }

      

        public void Update(Order entity)
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
