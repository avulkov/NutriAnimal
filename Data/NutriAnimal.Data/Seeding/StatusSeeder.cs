using NutriAnimal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Data.Seeding
{
    public class StatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Statuses.Any())
            {
                return;
            }

            await dbContext.Statuses.AddAsync(new Status { Name = "Shipped"});
            await dbContext.Statuses.AddAsync(new Status { Name = "Pending" });
        }
    }
}
