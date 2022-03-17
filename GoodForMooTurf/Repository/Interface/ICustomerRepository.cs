using GoodForMooTurf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}
