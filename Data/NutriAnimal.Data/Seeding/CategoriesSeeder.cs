using NutriAnimal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Data.Seeding
{
    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Protein" });
            await dbContext.Categories.AddAsync(new Category { Name = "Creatin" });
            await dbContext.Categories.AddAsync(new Category { Name = "Pre-Workout" });
            await dbContext.Categories.AddAsync(new Category { Name = "Amino Acid" });
            await dbContext.Categories.AddAsync(new Category { Name = "Fat Burner" });
        }
    }
    }

