using GoodForMooTurf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository.Interface
{
    public interface IOrderItemRepository
    {
        bool SaveChanges();
        Task<IEnumerable<OrderItem>> GetOrderItems(int orderId);
        Task<OrderItem> GetOrderItemById(int Id);
        void CreateOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int Id);
    }
}
