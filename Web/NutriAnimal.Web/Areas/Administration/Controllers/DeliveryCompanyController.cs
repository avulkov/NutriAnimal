using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriAnimal.Data.Models;
using NutriAnimal.Services.DeliveyCompanies;
using NutriAnimal.Web.Areas.Administration.ViewModels.DeliveryCompany;
using NutriAnimal.Web.ViewModels;
using NutriAnimal.Web.ViewModels.DeliveryCompany;

namespace NutriAnimal.Web.Areas.Administration.Controllers
{
    public class DeliveryCompanyController : AdministrationController
    {
        private readonly IDeliveryCompanyService service;

        public DeliveryCompanyController(IDeliveryCompanyService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var allCompanies = await this.service.GetAllDeliveryCompanies()
                    .Where(company=>company.IsDeleted!=true).Select(deliveryCompany => new CreateDeliveryCompanyViewModel
                {
                    Id = deliveryCompany.Id,
                    Name = deliveryCompany.Name,
                    Description = deliveryCompany.Description,
                    Price=deliveryCompany.Price,
                
                }).ToListAsync();
                return this.View(allCompanies);
            }

            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDeliveryCompanyInputModel companyInputModel)
        {
            if (!this.ModelState.IsValid)
            {

                return this.View(companyInputModel);
            }
            var deliveryCompany = new CreateDeliveryCompanyInputModel
            {
                Name = companyInputModel.Name,
                Description = companyInputModel.Description,
                Price=companyInputModel.Price
            };
            await this.service.CreateDeliveryCompany(deliveryCompany);
            return this.Redirect("All");

        }

        public IActionResult Edit(string id)
        {
            var company = this.service.GetDeliveryCompanyById(id);
            return this.View(company);
        }

        [HttpPost]
        public async Task< IActionResult> Edit(EditDeliveryCompanyInputModel companyToEdit)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(companyToEdit);
            }
            await this.service.Edit(companyToEdit);

            return this.Redirect("/Administration/DeliveryCompany/All");
        }

        public IActionResult Delete()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            
            await this.service.Delete(id);

            return this.Redirect("/Administration/DeliveryCompany/All");
        }

    }
}