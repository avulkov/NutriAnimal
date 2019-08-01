﻿namespace NutriAnimal.Data.Models
{
    public class Product
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string Picture { get; set; }

        public string Brand { get; set; }

        public bool IsDeleted { get; set; }


    }
}
