using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using GoodForMooTurf.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TurfContext _context;

        public OrderRepository(TurfContext context)
        {
            _context = context;
        }
        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(int Id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Reference == Id);
            if (order != null)
                _context.Orders.Remove(order);
        }

        public async Task<Order> GetOrderById(int Id)
        {
            return await _context.Orders.FindAsync(Id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.Include(order => order.Customer).Include(order => order.User).AsNoTracking().ToListAsync();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
