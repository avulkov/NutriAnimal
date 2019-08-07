using System.Collections.Generic;

namespace NutriAnimal.Web.ViewModels.Order
{
    public class ApplicationUserServiceModel
    {
        public string FullName { get; set; }

        public List<OrderServiceModel> Orders { get; set; }
    }
}