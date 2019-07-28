using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriAnimal.Services;
using NutriAnimal.Services.Product;
using NutriAnimal.Web.ViewModels.Category;
using NutriAnimal.Web.ViewModels.Product;

namespace NutriAnimal.Web.Areas.Administration.Controllers
{
    public class ProductController : AdministrationController
    {
        private readonly IProductService productService;
        private readonly ICLoudinaryService cLoudinaryService;

        public ProductController(IProductService productService, ICLoudinaryService cLoudinaryService)
        {
            this.productService = productService;
            this.cLoudinaryService = cLoudinaryService;
        }

        public async Task<IActionResult> Create()
        {
            var allCategories = await this.productService.GetAllCategories().ToListAsync();
            this.ViewData["categories"] = allCategories.Select(category => new CreateCategoryInputModel
            {
                Name = category.Name,
            })
           .ToList();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel productModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allCategories = await this.productService.GetAllCategories().ToListAsync();
                this.ViewData["categories"] = allCategories.Select(category => new CreateCategoryInputModel
                {
                    Name = category.Name,
                })
               .ToList();
                return this.View(); 
            }

            string pictureUrl = await this.cLoudinaryService.UploadPicture(productModel.Picture,productModel.Name);
            var product = new CreateProductServiceModel
            {
                Name = productModel.Name,
                Weight = productModel.Weight,
                Price = productModel.Price,
                Description = productModel.Description,
                Category = productModel.Category,
                Picture= pictureUrl,
                Brand=productModel.Brand,
            };

            await this.productService.Create(product);

            return this.Redirect("/");
        }
    }
}