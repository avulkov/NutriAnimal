namespace NutriAnimal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NutriAnimal.Services.Product;
    using NutriAnimal.Web.ViewModels.Product;
    using System.Linq;

    public class HomeController : BaseController
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var products = this.productService.GetAllProducts().Select(product => new CreateProductInputModel
            {
                Name = product.Name,
                Price = product.Price,
            }).ToList();
             
            return this.View(products);
        }
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
