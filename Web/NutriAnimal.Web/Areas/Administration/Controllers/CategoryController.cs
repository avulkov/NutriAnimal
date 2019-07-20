using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Data;
using NutriAnimal.Services.Category;
using NutriAnimal.Web.ViewModels.Category;

namespace NutriAnimal.Web.Areas.Administration.Controllers
{
    public class CategoryController : AdministrationController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("/Administration/Category/Create")]
        public async Task<IActionResult> CreateAsync(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model ?? new CreateCategoryInputModel());
            }

            var category = new CreateCategoryInputModel
            {
                Name = model.Name,
            };

            await this.service.CreateAsync(category);
            return this.Redirect("/");
        }


    }
}