﻿using NutriAnimal.Data;
using NutriAnimal.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(CreateCategoryInputModel model)
        {
            
            var category = new NutriAnimal.Data.Models.Category
            {
                Name = model.Name,
            };
            await this.context.Categories.AddAsync(category);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
