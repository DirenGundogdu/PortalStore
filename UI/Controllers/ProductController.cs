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
            var GetProduct = _apiHandler.GetApi<Resultmodel<ProductDto>>(productUrl);
            if (GetProduct.DataList != null)
            {
                product.ProductList = GetProduct.DataList;
            }
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryListUrl;
            var GetCategory = _apiHandler.GetApi<Resultmodel<CategoryDto>>(categoryUrl);
            if (GetCategory.DataList != null)
            {
                product.CategoryDtos = GetCategory.DataList;
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ProductVM product = new ProductVM();
            var productUrl = _config["BaseURL"] + UrlStrings.ProductListUrl;
            var GetProduct = _apiHandler.GetApi<Resultmodel<ProductDto>>(productUrl);
            if (GetProduct.DataList != null)
            {
                product.ProductList = GetProduct.DataList;
            }
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryListUrl;
            var GetCategory = _apiHandler.GetApi<Resultmodel<CategoryDto>>(categoryUrl);
            if (GetCategory.DataList != null)
            {
                product.CategoryDtos = GetCategory.DataList;
            }

            return View(product);
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
            ProductVM product = new ProductVM();
            var productUrl = _config["BaseURL"] + UrlStrings.ProductGetUrl + "/" + id;
            var GetProduct = _apiHandler.GetApi<Resultmodel<ProductProcessDto>>(productUrl);
            if (GetProduct.Data != null)
            {
                product.Product = GetProduct.Data;
            }
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryListUrl;
            var GetCategory = _apiHandler.GetApi<Resultmodel<CategoryDto>>(categoryUrl);
            if (GetCategory.DataList != null)
            {
                product.CategoryDtos = GetCategory.DataList;
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Update(ProductProcessDto productProcess)
        {
            var productUrl = _config["BaseURL"] + UrlStrings.ProductUpdateUrl;
            var post = _apiHandler.PostApi<Resultmodel<ProductProcessDto>>(productProcess, productUrl);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var productUrl = _config["BaseURL"] + UrlStrings.ProductRemoveUrl + "/" + id;
            var delete = _apiHandler.GetApi<Resultmodel<ProductProcessDto>>(productUrl);
            return RedirectToAction("Index");
        }

    }
}
