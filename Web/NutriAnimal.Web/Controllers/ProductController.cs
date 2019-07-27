using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Services.Product;
using NutriAnimal.Web.ViewModels.Product;

namespace NutriAnimal.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            CreateProductInputModel product = this.productService.GetProductById(id);

            return this.View(product);
        }
    }
}