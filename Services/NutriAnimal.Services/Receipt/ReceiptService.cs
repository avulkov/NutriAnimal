using NutriAnimal.Data;
using NutriAnimal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NutriAnimal.Services.Receipt
{
    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationDbContext context;

        public ReceiptService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void CreateReceipt(string issuerId)
        {
            var orders = this.context.Orders
                 .Where(order => order.IssuerId == issuerId && order.Status.Name == "Active")
                 .ToList();
            var allPrice = 0M;
            double allWeight = 0;

            var receipt = new NutriAnimal.Data.Models.Receipt
            {
                IssuedOn = DateTime.UtcNow,
                RecipientId = issuerId,
            };
            foreach (var item in orders)
            {
                receipt.Orders.Add(item);
            }

            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();
        }

        public List<Data.Models.Receipt> GetAllReceipts()
        {
            var receipts = this.context.Receipts.ToList();
            return receipts;
        }

        public List<Data.Models.Order> GetOrdersByReceiptId(string id)
        {
            var orders = this.context.Orders.Where(order => order.ReceiptId == id).ToList();
            return orders;
        }
    }
}
