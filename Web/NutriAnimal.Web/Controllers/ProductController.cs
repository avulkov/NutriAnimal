using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriAnimal.Data;
using NutriAnimal.Data.Models;
using NutriAnimal.Services.Category;
using NutriAnimal.Services.Order;
using NutriAnimal.Services.Pagination;
using NutriAnimal.Services.Product;
using NutriAnimal.Web.ViewModels.Category;
using NutriAnimal.Web.ViewModels.Order;
using NutriAnimal.Web.ViewModels.Product;

namespace NutriAnimal.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext context;

        public ProductController(IProductService productService, IOrderService orderService,ICategoryService categoryService,ApplicationDbContext context)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.categoryService = categoryService;
            this.context = context;
        }
      public async Task<IActionResult> GetProteins(string sortOrder,
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

            var products = from s in this.context.Products.Where(p => p.Category.Name == "Protein")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            int pageSize = 6;
           
            return this.View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> GetAminoAcids(string sortOrder,
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

            var products = from s in this.context.Products.Where(p => p.Category.Name == "Amino Acid")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            int pageSize = 6;

            return this.View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> GetFatBurners(string sortOrder,
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

            var products = from s in this.context.Products.Where(p => p.Category.Name == "Fat Burner")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            int pageSize = 6;

            return this.View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> GetCreatins(string sortOrder,
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

            var products = from s in this.context.Products.Where(p => p.Category.Name == "Creatin")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            int pageSize = 6;

            return this.View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> GetPreWorkouts(string sortOrder,
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

            var products = from s in this.context.Products.Where(p => p.Category.Name == "Pre-Workout")
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }


            int pageSize = 6;

            return this.View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var product = this.productService.GetProductById(id);

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Order(ProductOrderInputModel productOrderInputModel)
        {
            var orderServiceModel = new OrderServiceModel
            {
                ProductId = productOrderInputModel.ProductId,
                Quantity = productOrderInputModel.Quantity,
            };

            orderServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.orderService.CreateOrder(orderServiceModel);

            return this.Redirect("/");
        }

    }
}