using Ekka_Shopping.Models;
using Ekka_Shopping.Repositories;
using Ekka_Shopping.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ekka_Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductRepository _Productrepo;

        public HomeController(ILogger<HomeController> logger,IProductRepository Productrepo)
        {
            _logger = logger;
            _Productrepo = Productrepo;


        }

        public async Task<IActionResult> Index()
        {
            var pro = await _Productrepo.GetAllProducts();
            return View(pro);
            
        }

        public IActionResult Product_Sort(string entityType, int entityId)
        {
            IEnumerable<Product> products = null;

            switch (entityType.ToLower())
            {
                case "gender":
                    products = _Productrepo.GetProductsByGender(entityId);
                    break;

                case "category":
                    products = _Productrepo.GetProductsByCategory(entityId);
                    break;

                case "subcategory":
                    products = _Productrepo.GetProductsBySubcategory(entityId);
                    break;

                case "product":
                    var product = _Productrepo.GetProductsById(entityId);
                    if (product != null)
                    {
                        products = new List<Product> { product };
                    }
                    break;

                default:
                    return BadRequest("Invalid entity type");
            }

            if (products == null)
            {
                return NotFound("No products found for the given entity");
            }

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
