using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Data.Models;
using NutriAnimal.Services.Delivery;
using NutriAnimal.Services.Order;
using NutriAnimal.Services.Product;
using NutriAnimal.Services.Receipt;
using NutriAnimal.Web.ViewModels.Receipt;

namespace NutriAnimal.Web.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IDeliveryService deliveryService;

        public ReceiptController(IReceiptService receiptService,IOrderService orderService,IProductService productService,IDeliveryService deliveryService)
        {
            this.receiptService = receiptService;
            this.orderService = orderService;
            this.productService = productService;
            this.deliveryService = deliveryService;
        }
        public IActionResult All ()
        {
            var orders = this.receiptService.GetAllReceipts().Where(order => order.RecipientId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return this.View(orders);
        }
      
        public IActionResult Details(string id)
        {
            
            var receipt = this.receiptService.GetAllReceipts().FirstOrDefault(receiptDb=>receiptDb.Id == id);
            var targetOrder = this.receiptService.GetOrdersByReceiptId(receipt.Id).First();
            targetOrder.Delivery = this.deliveryService.GetDeliveryById(targetOrder.Id);
            var orders = this.receiptService.GetOrdersByReceiptId(id).Select(order=>new ReceiptDetailsOrderViewModel {
                ProductName=this.productService.GetProductById(order.ProductId).Name,
                ProductPrice= this.productService.GetProductById(order.ProductId).Price,
                Quantity=order.Quantity,
                Delivery=this.deliveryService.GetDeliveryById(order.DeliveryId)
            }).ToList();

            var receiptDetailsViewModel = new ReceiptDetailsViewModel {
                Id = receipt.Id,
                IssuedOn = receipt.IssuedOn,
                Orders = orders,
                DeliveryPrice = targetOrder.Delivery.Price,

            };

            return this.View(receiptDetailsViewModel);
        }
    }
}