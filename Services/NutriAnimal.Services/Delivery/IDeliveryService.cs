using NutriAnimal.Web.ViewModels.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services.Delivery
{
   public interface IDeliveryService
    {
        List<DeliveryOrderTypeViewModel> GetDeliveryTypes();

        Task<bool> CompleteOrder(CreateDeliveryInputModel inputModel);

        Data.Models.Delivery GetDeliveryById(string id);
    }
}
