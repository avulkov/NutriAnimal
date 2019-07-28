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

        public async Task<bool> Create(CreateProductServiceModel inputModel)
        {
            var categoryFromDb = this.context.Categories.FirstOrDefault(category => category.Name == inputModel.Category);
            var product = new NutriAnimal.Data.Models.Product
            {
                Name = inputModel.Name,
                Weight = inputModel.Weight,
                Price = inputModel.Price,
                Description = inputModel.Description,
                Brand = inputModel.Brand,
                Picture = inputModel.Picture


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

        public IQueryable<ProductHomeViewModel> GetAllProducts()
        {
            return this.context.Products.Select(product => new ProductHomeViewModel
            {
                Id = product.Id,
                Brand = product.Brand,
                Name = product.Name,
                Price = product.Price,
                Picture = product.Picture,

            });
        }

        public ProductDetailsViewModel GetProductById(string id)
        {
            var productFromDb = this.context.Products.FirstOrDefault(product => product.Id == id);
            ProductDetailsViewModel result = new ProductDetailsViewModel
            {
                Id = productFromDb.Id,
                Price = productFromDb.Price,
                Description = productFromDb.Description,
                Weight = productFromDb.Weight,
                Name = productFromDb.Name,
                Picture = productFromDb.Picture,
                Brand=productFromDb.Brand,
            };
            return result;
        }
    }
}
