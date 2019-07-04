using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskOrdersApplication.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int Unit { get; set; }
        [Required]

        public double Amount { get; set; }
        [Required]
        public Order OrderOfTheItem { get; set; }
    }

}