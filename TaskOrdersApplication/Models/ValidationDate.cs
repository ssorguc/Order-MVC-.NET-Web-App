using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TaskOrdersApplication.Models
{
    //Example of custom validation
    public class ValidationDate: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;
            if (order.DateOfOrder == null) return new ValidationResult("Date of order is requiered");

            if (order.DateOfOrder.Year > 2021) return new ValidationResult("Date must be in the near future!");
            

            return ValidationResult.Success;

        }
    }
}