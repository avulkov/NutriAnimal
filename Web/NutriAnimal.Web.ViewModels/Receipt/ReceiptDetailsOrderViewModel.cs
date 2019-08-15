namespace NutriAnimal.Web.ViewModels.Receipt
{
    public class ReceiptDetailsOrderViewModel
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public Data.Models.Delivery Delivery { get; set; }


    }
}