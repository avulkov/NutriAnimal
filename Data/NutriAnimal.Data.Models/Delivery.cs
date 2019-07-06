using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
   public class Delivery
    {
        public int Id { get; set; }

        public decimal Price { get; set; }


        public ApplicationUser Recipient { get; set; }

        public DeliveryCompany DeliveryCompany { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public Order Order { get; set; }

        



    }
}
