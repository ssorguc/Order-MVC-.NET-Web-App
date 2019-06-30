using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskOrdersApplication.Models;

namespace TaskOrdersApplication.ViewModels
{
    public class OrderItemsSaveView
    {
       public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}