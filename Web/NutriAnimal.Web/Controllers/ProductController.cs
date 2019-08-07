using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Data.Models;
using NutriAnimal.Services.Order;
using NutriAnimal.Services.Product;
using NutriAnimal.Web.ViewModels.Order;
using NutriAnimal.Web.ViewModels.Product;

namespace NutriAnimal.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var product = this.productService.GetProductById(id);

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Order(ProductOrderInputModel productOrderInputModel)
        {
            var orderServiceModel = new OrderServiceModel
            {
                ProductId = productOrderInputModel.ProductId,
                Quantity = productOrderInputModel.Quantity,
            };

            orderServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.orderService.CreateOrder(orderServiceModel);

            return this.Redirect("/");
        }

    }
}