using NutriAnimal.Web.ViewModels.Order;
using NutriAnimal.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services.Order
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderServiceModel orderServiceModel);

        IQueryable<CartViewModel> GetAllOrders();

        Task<bool> ReduceQuantity(string orderId);

        Task<bool> IncreaseQuantity(string orderId);
    }
}
