using NutriAnimal.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Delivery
{
    public class CreateDeliveryInputModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Recipient { get; set; }
       
       
        [Required]
        public string DeliveryCompany { get; set; }
        
        
        [Required]
        public string DeliveryType { get; set; }
        
        public string IssuedById { get; set; }

        public ApplicationUser IssuedBy { get; set; }
    }
}
