using System.Collections.Generic;

namespace GoodForMooTurf.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
