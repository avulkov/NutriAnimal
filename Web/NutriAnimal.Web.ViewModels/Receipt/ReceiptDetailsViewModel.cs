using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Web.ViewModels.Receipt
{
   public class ReceiptDetailsViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public List<ReceiptDetailsOrderViewModel> Orders { get; set; }

        public decimal DeliveryPrice { get; set; }

    }
}
