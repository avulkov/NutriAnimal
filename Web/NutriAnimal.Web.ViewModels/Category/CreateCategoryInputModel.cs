using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Category
{
    public class CreateCategoryInputModel
    {
        [Requred]
        [Display(Name="Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
    }
}
