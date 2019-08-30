using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Data;
using NutriAnimal.Web.ViewModels.DeliveryCompany;

namespace NutriAnimal.Web.Controllers
{
    public class DeliveryCompanyController : Controller
    {
        private readonly ApplicationDbContext context;

        public DeliveryCompanyController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize]
        public IActionResult All()
        {
            var deliveryCompanies = this.context.DeliveryCompanies.Select(company => new DetailsDeliveryCompanyViewModel
            {
                Name = company.Name,
                Description = company.Description,
                Price = company.Price,

            }).ToList();

            return this.View(deliveryCompanies);
        }
    }
}