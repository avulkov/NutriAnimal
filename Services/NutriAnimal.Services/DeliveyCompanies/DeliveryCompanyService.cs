using Microsoft.EntityFrameworkCore;
using NutriAnimal.Data;
using NutriAnimal.Data.Models;
using NutriAnimal.Web.ViewModels;
using NutriAnimal.Web.ViewModels.DeliveryCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NutriAnimal.Services.DeliveyCompanies
{
   public class DeliveryCompanyService : IDeliveryCompanyService
    {
        private readonly ApplicationDbContext context;

        public DeliveryCompanyService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateDeliveryCompany(CreateDeliveryCompanyInputModel deliveryCompanyInputModel)
        {
            var deliveryCompany = new DeliveryCompany
            {
                Name = deliveryCompanyInputModel.Name,
                Description = deliveryCompanyInputModel.Description,
                IsDeleted = false,
            };

            this.context.DeliveryCompanies.Add(deliveryCompany);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var companyToDelete = this.GetDeliveryCompanyById(id);
            companyToDelete.IsDeleted = true ;
            this.context.DeliveryCompanies.Update(companyToDelete);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Edit(EditDeliveryCompanyInputModel companyToEdit)
        {
            var company = this.GetDeliveryCompanyById(companyToEdit.Id);

            company.Name = companyToEdit.Name;
            company.Description = companyToEdit.Description;
            this.context.DeliveryCompanies.Update(company);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<CreateDeliveryCompanyInputModel> GetAllDeliveryCompanies()
        {
            var allCompanies = this.context.DeliveryCompanies.Select(deliveryCompany => new CreateDeliveryCompanyInputModel
            {
                Id=deliveryCompany.Id,
                Name = deliveryCompany.Name,
                Description = deliveryCompany.Description,
                IsDeleted=deliveryCompany.IsDeleted,
            });
            return allCompanies;
        }

        public DeliveryCompany GetDeliveryCompanyById(string id)
        {
          var companyFromDb = this.context.DeliveryCompanies.SingleOrDefault(company => company.Id == id);
          return companyFromDb;
        }
    }
}
