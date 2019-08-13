using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Services.Delivery;
using NutriAnimal.Services.DeliveyCompanies;
using NutriAnimal.Web.ViewModels.Delivery;
using NutriAnimal.Web.ViewModels.DeliveryCompany;

namespace NutriAnimal.Web.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryCompanyService deliveryCompany;
        private readonly IDeliveryService deliveryService;

        public DeliveryController(IDeliveryCompanyService deliveryCompany,IDeliveryService deliveryService)
        {
            this.deliveryCompany = deliveryCompany;
            this.deliveryService = deliveryService;
        }
        public IActionResult Complete()
        {

            var allDeliveryCompanies = this.deliveryCompany.GetAllDeliveryCompanies().ToList();
            this.ViewData["deliveryCompanies"] = allDeliveryCompanies.Select(category => new CreateDeliveryCompanyInputModel
            {
                Name = category.Name,
            })
           .ToList();
            var allDeliveryTypes = this.deliveryService.GetDeliveryTypes();
            this.ViewData["deliveryTypes"] = allDeliveryTypes.Select(deliveryType => new DeliveryOrderTypeViewModel
            {
                Name = deliveryType.Name,
            })
           .ToList();
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Complete(CreateDeliveryInputModel deliveryModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allDeliveryCompanies = this.deliveryCompany.GetAllDeliveryCompanies().ToList();
                this.ViewData["deliveryCompanies"] = allDeliveryCompanies.Select(category => new CreateDeliveryCompanyInputModel
                {
                    Name = category.Name,
                })
               .ToList();
                var allDeliveryTypes = this.deliveryService.GetDeliveryTypes();
                this.ViewData["deliveryTypes"] = allDeliveryTypes.Select(deliveryType => new DeliveryOrderTypeViewModel
                {
                    Name = deliveryType.Name,
                })
               .ToList();
                return this.View();
            }
            var delivery = deliveryModel;
            delivery.IssuedById= this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
           await this.deliveryService.CompleteOrder(delivery);
            return this.Redirect("/");
        }
    }
}