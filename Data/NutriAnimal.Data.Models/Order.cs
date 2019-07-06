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
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public ICollection<Product> Products { get; set; }

        public double Weight { get; set; }


        public string Address { get; set; }


        public decimal TotalPrice { get; set; }

        public int DeliveryCompanyId { get; set; }

        public Status Status { get; set; }

        public ApplicationUser OrderedBy { get; set; }
        public DeliveryCompany DeliveryCompany { get; set; }


    }
}
