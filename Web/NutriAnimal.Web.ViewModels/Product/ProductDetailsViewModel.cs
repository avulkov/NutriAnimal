using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public bool IsDeleted { get; set; }
    }
}
