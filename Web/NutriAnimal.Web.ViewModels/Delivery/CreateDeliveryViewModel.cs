using NutriAnimal.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Delivery
{
   public class CreateDeliveryViewModel
    {


        public string Address { get; set; }

        public string Recipient { get; set; }

        public string DeliveryCompanyId { get; set; }

        public NutriAnimal.Data.Models.DeliveryCompany DeliveryCompany { get; set; }

        public string DeliveryTypeId { get; set; }

        public DeliveryType DeliveryType { get; set; }
    }
}
