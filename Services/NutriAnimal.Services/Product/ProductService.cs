using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutriAnimal.Data;
using NutriAnimal.Web.ViewModels.Category;
using NutriAnimal.Web.ViewModels.Product;

namespace NutriAnimal.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(CreateProductInputModel inputModel)
        {
            var categoryFromDb = this.context.Categories.FirstOrDefault(category => category.Name == inputModel.Category);
          var product = new NutriAnimal.Data.Models.Product
          {
              Name = inputModel.Name,
              Weight = inputModel.Weight,
              Price = inputModel.Price,
              Description = inputModel.Description,
             
              
          };
            product.Category = categoryFromDb;
            this.context.Products.Add(product);
            var result = await this.context.SaveChangesAsync();
            return result > 0;

        }

        public IQueryable<CreateCategoryInputModel> GetAllCategories()
        {
            return this.context.Categories.Select(category => new CreateCategoryInputModel
            {
                Name = category.Name,
            });
        }
    }
}
