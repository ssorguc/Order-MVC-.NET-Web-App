using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskOrdersApplication.Models;

namespace TaskOrdersApplication.ViewModels
{
    public class OrderListViewModel
    {
        public ICollection<Order> AllOrders { get; set; }
        
    }
}