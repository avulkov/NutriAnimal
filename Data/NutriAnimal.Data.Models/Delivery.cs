using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
    public class Delivery

    {
        public Delivery()
        {
            this.Orders = new List<Order>();
        }
        public string Id { get; set; }

        public decimal Price { get; set; }

        public string IssuedById { get; set; }

        public ApplicationUser IssuedBy { get; set; }

        public string Recipient { get; set; }

        public string DeliveryCompanyId { get; set; }

        public DeliveryCompany DeliveryCompany { get; set; }

        public string DeliveryTypeId { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public string Address { get; set; }

        public List<Order> Orders { get; set; }


    }
}
