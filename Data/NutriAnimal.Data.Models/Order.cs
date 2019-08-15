using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
   public class Order
    {

        public string Id { get; set; }

        public int Quantity { get; set; }
        //TODO Renameto ProductPrice
        public decimal TotalPrice { get; set; }

        public string StatusId { get; set; }

        public Status Status { get; set; }

        public DateTime OrderedOn { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string IssuerId { get; set; }

        public ApplicationUser Issuer { get; set; }

        public string ReceiptId { get; set; }

        public Receipt Receipt { get; set; }

        public string DeliveryId { get; set; }

        public Delivery Delivery { get; set; }





    }
}
