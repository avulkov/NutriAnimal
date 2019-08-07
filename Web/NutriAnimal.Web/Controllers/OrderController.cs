using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Services.Order;
using NutriAnimal.Services.Product;
using NutriAnimal.Web.ViewModels.Order;

namespace NutriAnimal.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public OrderController(IOrderService orderService,IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var product = this.productService.GetProductById();
        //    return this.View(product);
        //}
    }
}