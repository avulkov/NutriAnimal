using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Product
{
    public class CreateProductInputModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public double Weight { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Brand")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Brand { get; set; }

      
        [Display(Name = "Picture")]
        public IFormFile Picture { get; set; }
    }
}
