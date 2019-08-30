using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Services.Delivery;
using NutriAnimal.Services.DeliveyCompanies;
using NutriAnimal.Services.Receipt;
using NutriAnimal.Web.ViewModels.Delivery;
using NutriAnimal.Web.ViewModels.DeliveryCompany;

namespace NutriAnimal.Web.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveryCompanyService deliveryCompanyService;
        private readonly IDeliveryService deliveryService;
        private readonly IReceiptService receiptService;

        public DeliveryController(IDeliveryCompanyService deliveryCompanyService,IDeliveryService deliveryService,IReceiptService receiptService)
        {
            this.deliveryCompanyService = deliveryCompanyService;
            this.deliveryService = deliveryService;
            this.receiptService = receiptService;
        }
        [Authorize]
        public IActionResult Complete()
        {

            var allDeliveryCompanies = this.deliveryCompanyService.GetAllDeliveryCompanies().ToList();
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Complete(CreateDeliveryInputModel deliveryModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allDeliveryCompanies = this.deliveryCompanyService.GetAllDeliveryCompanies().ToList();
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
            this.receiptService.CreateReceipt(delivery.IssuedById);
            await this.deliveryService.CompleteOrder(delivery);
            return this.Redirect("/Receipt/All");
        }
        [Authorize]
        public IActionResult All()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var deliveries = this.deliveryService.GetAllDeliveries().Where(delivery => delivery.IssuedById == userId).ToList();
            return this.View(deliveries);
        }
        
    }
}