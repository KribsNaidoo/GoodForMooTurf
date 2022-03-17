using GoodForMooTurf.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodForMooTurf.Context
{
    public class TurfContext: DbContext
    {
        #region DBSET
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        #endregion

        #region Context
        public TurfContext(DbContextOptions<TurfContext> options): base(options)
        {

        }
        #endregion

        #region Overide
        // Override onModelCreating to insert data upon database update
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer[] {
                new Customer{ Id = 1, Name = "Adam" },
                new Customer{ Id = 2, Name = "Bob" },
                new Customer{ Id = 3, Name = "Chris" },
                new Customer{ Id = 4, Name = "Dave" },
            });

            modelBuilder.Entity<User>().HasData(new User[] {
                new User{ Id = 1, Name = "John", Password = "J0hn" },
                new User{ Id = 2, Name = "Doe", Password = "D0e" },
            });

            modelBuilder.Entity<Order>().HasData(new Order[] {
                new Order{ Reference = 1, CaptureDate = new System.DateTime(2022, 3, 15), DueDate = new System.DateTime(2022, 3, 31), UserId = 1, VAT = 20, GrandTotal = 1800, SubTotal = 1500, TotalVAT = 300, CustomerId = 1 },
                new Order{ Reference = 2, CaptureDate = new System.DateTime(2022, 3, 16), DueDate = new System.DateTime(2022, 3, 25), UserId = 1, VAT = 10, GrandTotal = 2200, SubTotal = 2000, TotalVAT = 200, CustomerId = 3 },
                new Order{ Reference = 3, CaptureDate = new System.DateTime(2022, 3, 17), DueDate = new System.DateTime(2022, 3, 20), UserId = 1, VAT = 25, GrandTotal = 3750, SubTotal = 3000, TotalVAT = 750, CustomerId = 4 }
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem[] {
                new OrderItem{ Id = 1, Description = "Dichondra", UnitCostAmount = 150, Quantity = 10 , TotalAmount = 1500, OrderId = 1},
                new OrderItem{ Id = 2, Description = "Perennial Ryegrass", UnitCostAmount = 500, Quantity = 4 , TotalAmount = 2000, OrderId = 3},
                new OrderItem{ Id = 3, Description = "Bermuda", UnitCostAmount = 750, Quantity = 4 , TotalAmount = 3000, OrderId = 2}
            });
        }

        #endregion
    }
}
