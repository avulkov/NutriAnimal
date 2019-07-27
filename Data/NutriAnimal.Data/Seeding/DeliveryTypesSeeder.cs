using NutriAnimal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Data.Seeding
{
    public class DeliveryTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.DeliveryTypes.Any())
            {
                return;
            }

            await dbContext.DeliveryTypes.AddAsync(new DeliveryType { Name = "To Office" });
            await dbContext.DeliveryTypes.AddAsync(new DeliveryType { Name = "To Address" });
        }
    }
}
