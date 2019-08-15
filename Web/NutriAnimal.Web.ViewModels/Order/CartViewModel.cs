using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Order
{
   public class CartViewModel
    {
        public string Id { get; set; }

        public string IssuerId { get; set; }

        public string ProductPicture { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        
    }
}
