using DTO;
using Microsoft.AspNetCore.Mvc;
using UI.ApiHandler;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IApiHandler _apiHandler;

        public ProductController(IApiHandler apiHandler, IConfiguration config)
        {
            _apiHandler = apiHandler;
            _config = config;
        }

        public IActionResult Index()
        {
            ProductVM product = new ProductVM();
            var productUrl = _config["BaseURL"] + UrlStrings.ProductListUrl;
            var GetProduct=_apiHandler.GetApi<Resultmodel<ProductDto>>(productUrl);
            if (GetProduct.DataList.Count > 0)
            {
                product.ProductList = GetProduct.DataList;
            }
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryList;
            var GetCategory=_apiHandler.GetApi<Resultmodel<CategoryDto>>(categoryUrl);
            if (GetCategory.DataList.Count > 0)
            {
                product.CategoryDtos = GetCategory.DataList;
            }

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductProcessDto productProcess)
        {
            var productUrl = _config["BaseURL"] + UrlStrings.ProductCreateUrl;
            var post = _apiHandler.PostApi<Resultmodel<ProductProcessDto>>(productProcess, productUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }

    }
}
