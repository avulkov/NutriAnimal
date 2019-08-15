using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
   public class Receipt
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public List<Order> Orders { get; set; }

        public string RecipientId { get; set; }

        public NutriAnimal.Data.Models.ApplicationUser Recipient { get; set; }
    }
}
