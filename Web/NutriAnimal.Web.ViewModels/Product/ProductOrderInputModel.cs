using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Product
{
    public class ProductOrderInputModel
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
