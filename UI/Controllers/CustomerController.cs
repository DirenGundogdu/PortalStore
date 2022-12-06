using DTO;
using Microsoft.AspNetCore.Mvc;
using UI.ApiHandler;
using UI.Models;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IApiHandler _apiHandler;

        public CustomerController(IApiHandler apiHandler, IConfiguration config)
        {
            _apiHandler = apiHandler;
            _config = config;
        }
        public IActionResult Index()
        {
            var url = _config["BaseURL"] + UrlStrings.CustomerListUrl;
            var GetProduct = _apiHandler.GetApi<Resultmodel<CustomerDto>>(url);
            return View(GetProduct.DataList);
        }

        public IActionResult Create() {
        
            return View();
         }

        [HttpPost]
        public IActionResult Create(CustomerDto customerDto)
        {
            var customerUrl = _config["BaseURL"] + UrlStrings.CustomerCreateUrl;
            var post = _apiHandler.PostApi<Resultmodel<CustomerDto>>(customerDto, customerUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Update() {
            return View();
        }
        [HttpPost]
        public IActionResult Update(CustomerDto customerDto)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remove()
        {
            return RedirectToAction("Index");
        }
    }
}
