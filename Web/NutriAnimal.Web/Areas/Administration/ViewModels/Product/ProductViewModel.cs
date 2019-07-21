using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NutriAnimal.Web.Areas.Administration.ViewModels.Product
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public NutriAnimal.Data.Models.Category Category { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }
    }
}
