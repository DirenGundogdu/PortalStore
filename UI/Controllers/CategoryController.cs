using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using UI.ApiHandler;
using UI.Models;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IApiHandler _apiHandler;

        public CategoryController(IApiHandler apiHandler, IConfiguration config)
        {
            _apiHandler = apiHandler;
            _config = config;
        }
        public IActionResult Index()
        {
            var url = _config["BaseURL"] + UrlStrings.CategoryListUrl;
            var GetCatogories = _apiHandler.GetApi<Resultmodel<CategoryDto>>(url);
            return View(GetCatogories.DataList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryCreateUrl;
            var post = _apiHandler.PostApi<Resultmodel<CategoryDto>>(categoryDto, categoryUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var url = _config["BaseURL"] + UrlStrings.CategoryGetUrl + "/" + id;
            var GetCatogories = _apiHandler.GetApi<Resultmodel<CategoryDto>>(url);
            return View(GetCatogories.Data);
        }
        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryUpdateUrl;
            var post = _apiHandler.PostApi<Resultmodel<CategoryDto>>(categoryDto, categoryUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var categoryUrl = _config["BaseURL"] + UrlStrings.CategoryRemoveUrl + "/" + id;
            var delete = _apiHandler.GetApi<Resultmodel<CategoryDto>>(categoryUrl);
            return RedirectToAction("Index");
        }
    }
}
