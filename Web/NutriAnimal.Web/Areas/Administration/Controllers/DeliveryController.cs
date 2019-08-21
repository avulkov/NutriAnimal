using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Services.Delivery;
using NutriAnimal.Web.ViewModels.Delivery;

namespace NutriAnimal.Web.Areas.Administration.Controllers
{
    public class DeliveryController : AdministrationController
    {
        private readonly IDeliveryService deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        public IActionResult All()
        {
            var deliveries = this.deliveryService.GetAllDeliveries();
            return this.View(deliveries);
        }

        public async Task<IActionResult> Ship(string id)
        {
            var delivery = this.deliveryService.GetDeliveryById(id);
            var deliveryToShip = new DeliveryViewModel { Id = delivery.Id };

            return this.View(deliveryToShip);
        }
        [HttpPost]
        public async Task<IActionResult> Ship(DeliveryViewModel deliveryViewModel)
        {

            var result = await this.deliveryService.ShipDelivery(deliveryViewModel.Id);

            return this.Redirect("/Administration/Delivery/All");
        }

        public async Task<IActionResult> Finish(string id)
        {

            var delivery = this.deliveryService.GetDeliveryById(id);
            var deliveryToFinish = new DeliveryViewModel { Id = delivery.Id };

            return this.View(deliveryToFinish);
        }
        [HttpPost]
        public async Task<IActionResult> Finish(DeliveryViewModel deliveryViewModel)
        {

            var result = await this.deliveryService.Finish(deliveryViewModel.Id);

            return this.Redirect("/Administration/Delivery/All");
        }

        
    }
}