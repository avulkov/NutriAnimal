using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NutriAnimal.Web.ViewModels.DeliveryCompany
{
   public class EditDeliveryCompanyInputModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100000000)]
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
