using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Delivery
{
   public class DeliveryViewModel
    {
        public string Id { get; set; }

        public string Recipient { get; set; }

        public string Status { get; set; }

        public string IssuedById { get; set; }
    }
}
