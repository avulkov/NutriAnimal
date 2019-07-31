using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriAnimal.Web.Areas.Administration.ViewModels.DeliveryCompany
{
    public class CreateDeliveryCompanyViewModel
    {
       

        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted{ get; set; }
    }
}
