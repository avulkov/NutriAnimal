﻿using Microsoft.AspNetCore.Mvc;
using NutriAnimal.Web.ViewModels.Category;
using NutriAnimal.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services.Product
{
    public interface IProductService
    {
        IQueryable<CreateCategoryInputModel> GetAllCategories();
        CreateProductInputModel GetProductById(string id);
        IQueryable<CreateProductInputModel> GetAllProducts();

        Task<bool> Create(CreateProductInputModel inputModel);

      
    }
}
