﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Product
{
    public class ProductHomeViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public bool IsDeleted { get; set; }

        public string Category { get; set; }

    }
}
