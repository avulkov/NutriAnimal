using NutriAnimal.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutriAnimal.Services.Category
{
    public interface ICategoryService

    {
        Task<bool> CreateAsync(CreateCategoryInputModel model);

    }
}
