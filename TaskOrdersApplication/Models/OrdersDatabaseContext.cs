using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace TaskOrdersApplication.Models
{
    
    public class OrdersDatabaseContext: DbContext
    {
        public OrdersDatabaseContext() : base()
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}