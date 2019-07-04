using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskOrdersApplication.Models;

namespace TaskOrdersApplication.ViewModel
{
    public class OrdersViewModel
    {
        public Order Order { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}