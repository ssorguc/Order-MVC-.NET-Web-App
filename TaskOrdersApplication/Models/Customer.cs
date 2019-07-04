using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskOrdersApplication.Models
{
    public class Customer
    {
        [Display(Name = "Customer ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have to enter your user name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "You have to enter the password to log in!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Orders of the Customer")]
        public ICollection<Order> AllCustomersOrders { get; set; }
    }
}