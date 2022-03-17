using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using GoodForMooTurf.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TurfContext _context;

        public CustomerRepository(TurfContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().ToList();
        }
    }
}
