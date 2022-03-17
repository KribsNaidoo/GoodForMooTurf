using GoodForMooTurf.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodForMooTurf.Repository.Interface
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
    }
}
