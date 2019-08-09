using Microsoft.EntityFrameworkCore;
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
                IssuerId = orderServiceModel.IssuerId,
            };
            var price = productFromDb.Price * orderServiceModel.Quantity;
            order.TotalPrice = price;
            var status = this.context.Statuses.FirstOrDefault(statusDb => statusDb.Name == "Active");
            order.Status = status;

            this.context.Orders.Add(order);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<CartViewModel> GetAllOrders()
        {
            return this.context.Orders.Where(order=>order.Status.Name == "Active").Select(order => new CartViewModel
            {
                Id=order.Id,
                ProductPrice = order.TotalPrice,
                ProductName = order.Product.Name,
                Quantity = order.Quantity,
                ProductPicture=order.Product.Picture,
                IssuerId=order.IssuerId
            });
        }
        public async Task<bool> IncreaseQuantity(string orderId)
        {
            NutriAnimal.Data.Models.Order orderFromDb = await this.context.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (orderFromDb == null)
            {
                throw new ArgumentNullException(nameof(orderFromDb));
            }

            orderFromDb.Quantity++;

            this.context.Update(orderFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ReduceQuantity(string orderId)
        {
            NutriAnimal.Data.Models.Order orderFromDb = await this.context.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (orderFromDb == null)
            {
                throw new ArgumentNullException(nameof(orderFromDb));
            }

            if (orderFromDb.Quantity == 1)
            {
                return false;
            }

            orderFromDb.Quantity--;

            this.context.Update(orderFromDb);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

    }
}
