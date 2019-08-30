using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public IActionResult Cart()
        {
            var orders = this.orderService.GetAllOrders().Where(order => order.IssuerId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
           
            return this.View(orders);
        }
        [HttpPost]
        [Authorize]
        [Route("/Order/{id}/Quantity/Reduce")]
        public async Task<IActionResult> Reduce(string id)
        {
            bool result = await this.orderService.ReduceQuantity(id);

            if (result)
            {
                return this.Ok();
            }
            else
            {
                return this.Forbid();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("/Order/{id}/Quantity/Increase")]
        public async Task<IActionResult> Increase(string id)
        {
            bool result = await this.orderService.IncreaseQuantity(id);

            if (result)
            {
                return this.Ok();
            }
            else
            {
                return this.Forbid();
            }
        }
    }
}