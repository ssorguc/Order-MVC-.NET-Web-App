using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskOrdersApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
   
        public Customer Customer { get; set; }
            
        [Required]
        [ValidationDate]
        [Display(Name ="Date of the Order")]
        public DateTime DateOfOrder { get; set; }

        [Required]
        [Display(Name ="Total Amount in USD")]
        public double TotalAmount { get { return CalculateTotalAmount(); } }

        [Required]
        public ICollection<OrderItem> OrderedItems { get; set; }
        private double CalculateTotalAmount()
        {
            double sum = 0;
            if (OrderedItems == null) return 0;
            foreach (OrderItem item in OrderedItems) sum += item.Amount * item.Unit;
            return sum;
        }
    }
}