namespace NutriAnimal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NutriAnimal.Data;
    using NutriAnimal.Data.Models;
    using NutriAnimal.Services.Pagination;
    using NutriAnimal.Services.Product;
    using NutriAnimal.Web.ViewModels.Product;
    using ReflectionIT.Mvc.Paging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
   

    public class HomeController : BaseController
    {
        private readonly IProductService productService;
        private readonly ApplicationDbContext context;

        public HomeController(IProductService productService,ApplicationDbContext context)
        {
            this.productService = productService;
            this.context = context;
        }
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var products = from s in this.context.Products
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            int pageSize = 6;
            return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        //public async Task< IActionResult> Index(int page = 1)
        //{
        //    var query = this.context.Products.AsNoTracking().OrderBy(p => p.Id);
        //    var moderl = await PagingList.CreateAsync(query,3,page);
        //    //var products = this.productService.GetAllProducts().Select(product => new ProductHomeViewModel
        //    //{
        //    //    Id = product.Id,
        //    //    Name = product.Name,
        //    //    Price = product.Price,
        //    //    Picture = product.Picture,

        //    //}).ToList();

        //    return this.View(moderl);
        //}
        





    }
}
