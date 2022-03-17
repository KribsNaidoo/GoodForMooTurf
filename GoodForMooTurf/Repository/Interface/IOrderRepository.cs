using GoodForMooTurf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository.Interface
{
    public interface IOrderRepository
    {
        bool SaveChanges();
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int Id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int Id);
    }
}
