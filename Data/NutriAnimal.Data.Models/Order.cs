using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
   public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }

        public string Id { get; set; }

        public double Weight { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public string DeliveryCompanyId { get; set; }

        public DeliveryCompany DeliveryCompany { get; set; }

        public string StatusId { get; set; }

        public Status Status { get; set; }

        public string OrderedById { get; set; }

        public ApplicationUser OrderedBy { get; set; }

        public DateTime OrderedOn { get; set; }

        public ICollection<Product> Products { get; set; }



    }
}
