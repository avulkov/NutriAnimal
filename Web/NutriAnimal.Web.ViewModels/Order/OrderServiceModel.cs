using NutriAnimal.Data.Models;
using NutriAnimal.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Order
{
    public class OrderServiceModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string ProductId { get; set; }

        public ProductDetailsViewModel Product { get; set; }

        public int Quantity { get; set; }

        public string IssuerId { get; set; }

        public ApplicationUser Issuer { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
