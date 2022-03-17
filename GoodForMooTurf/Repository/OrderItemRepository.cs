using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using GoodForMooTurf.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TurfContext _context;

        public OrderItemRepository(TurfContext context)
        {
            _context = context;
        }

        public void CreateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(int orderId)
        {
            return await _context.OrderItems.AsNoTracking().Where(x => x.OrderId == orderId).ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemById(int Id)
        {
            return await _context.OrderItems.FindAsync(Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }

        public void DeleteOrderItem(int Id)
        {
            var orderItem = _context.OrderItems.FirstOrDefault(x => x.Id == Id);
            if (orderItem != null)
                _context.OrderItems.Remove(orderItem);
        }
    }
}
