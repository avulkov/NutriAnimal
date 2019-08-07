using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutriAnimal.Data;
using NutriAnimal.Web.ViewModels.Category;
using NutriAnimal.Web.ViewModels.Product;
using NutriAnimal.Data.Models;
using NutriAnimal.Web.ViewModels.Order;

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
                Picture = inputModel.Picture,
              


            };
            product.Category = categoryFromDb;
            this.context.Products.Add(product);
            var result = await this.context.SaveChangesAsync();
            return result > 0;

        }

        public async Task<bool> Delete(string id)
        {
            var productToDelete = this.context.Products.SingleOrDefault(x => x.Id == id);
            productToDelete.IsDeleted = true;


            this.context.Products.Update(productToDelete);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Edit(CreateProductInputModel modelToEdit, string pictureUrl)
        {
            var productFromDb = this.context.Products.SingleOrDefault(product => product.Id == modelToEdit.Id);
            var categoryFromDb = this.context.Categories.SingleOrDefault(category => category.Id == productFromDb.CategoryId);

            productFromDb.Name = modelToEdit.Name;
            productFromDb.Weight = modelToEdit.Weight;
            productFromDb.Description = modelToEdit.Description;
            productFromDb.Brand = modelToEdit.Brand;
            productFromDb.Price = modelToEdit.Price;
            productFromDb.Category = categoryFromDb;
            if (modelToEdit.Picture != null)
            {
                productFromDb.Picture = pictureUrl;

            }

            this.context.Products.Update(productFromDb);
            int result = await this.context.SaveChangesAsync();

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
            return this.context.Products.Where(x=>x.IsDeleted!=true).Select(product => new ProductHomeViewModel
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
            var productFromDb = this.context.Products.SingleOrDefault(product => product.Id == id);
            ProductDetailsViewModel result = null;
            if (productFromDb != null)
            {
                var category = this.context.Categories.FirstOrDefault(x => x.Id == productFromDb.CategoryId);
                result = new ProductDetailsViewModel
                {
                    Id = productFromDb.Id,
                    Price = productFromDb.Price,
                    Description = productFromDb.Description,
                    Weight = productFromDb.Weight,
                    Name = productFromDb.Name,
                    Picture = productFromDb.Picture,
                    Brand = productFromDb.Brand,
                    Category = category.Name,
                };
            }

            return result;
        }

        
    }
}
