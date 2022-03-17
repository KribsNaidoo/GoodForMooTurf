using GoodForMooTurf.Context;
using GoodForMooTurf.Models;
using GoodForMooTurf.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TurfContext _context;

        public UsersRepository(TurfContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.AsNoTracking().ToList();
        }
    }
}
