using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Services.Receipt
{
   public interface IReceiptService
    {
        void CreateReceipt(string issuerId);

        List<NutriAnimal.Data.Models.Receipt> GetAllReceipts();

        List<NutriAnimal.Data.Models.Order> GetOrdersByReceiptId(string id);
    }
}
