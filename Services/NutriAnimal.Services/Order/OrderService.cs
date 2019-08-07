using NutriAnimal.Data;
using NutriAnimal.Services.Product;
using NutriAnimal.Web.ViewModels.Order;
using NutriAnimal.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services.Order
{
    public class OrderService : IOrderService

    {
        private readonly ApplicationDbContext context;
        private readonly IProductService productService;

        public OrderService(ApplicationDbContext context, IProductService productService)
        {
            this.context = context;
            this.productService = productService;
        }
        public async Task<bool> CreateOrder(OrderServiceModel orderServiceModel)

        {
            var productFromDb = this.context.Products.SingleOrDefault(product => product.Id == orderServiceModel.ProductId);
            var order = new NutriAnimal.Data.Models.Order
            {
                ProductId = orderServiceModel.ProductId,
                Quantity = orderServiceModel.Quantity,
                OrderedOn = DateTime.UtcNow,
                IssuerId=orderServiceModel.IssuerId,
            };
            var price = productFromDb.Price * orderServiceModel.Quantity;
            order.TotalPrice = price;
            var status = this.context.Statuses.FirstOrDefault(statusDb => statusDb.Name == "Active");
            order.Status = status;

            this.context.Orders.Add(order);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }
    }
}
