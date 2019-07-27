using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutriAnimal.Data.Models;
using NutriAnimal.Web.ViewModels.DeliveryCompany;

namespace NutriAnimal.Services.DeliveyCompanies
{
    public interface IDeliveryCompanyService
    {
        IQueryable<CreateDeliveryCompanyInputModel> GetAllDeliveryCompanies();
        Task<bool> CreateDeliveryCompany(CreateDeliveryCompanyInputModel deliveryCompanyInputModel);
        Task<bool> Edit(EditDeliveryCompanyInputModel companyToEdit);
        DeliveryCompany GetDeliveryCompanyById(string id);
        Task<bool> Delete(EditDeliveryCompanyInputModel companyToEdit);
    }
}
