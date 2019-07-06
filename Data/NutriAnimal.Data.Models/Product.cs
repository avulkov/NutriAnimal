using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
   public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public Order Order { get; set; }


    }
}
