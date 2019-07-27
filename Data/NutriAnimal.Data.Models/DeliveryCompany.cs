namespace NutriAnimal.Data.Models
{
    public class DeliveryCompany
    {
        public DeliveryCompany()
        {
            this.IsDeleted = false;
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted  { get; set; }
    }
}