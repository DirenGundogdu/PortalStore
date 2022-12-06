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

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerDto customerDto)
        {
            var customerUrl = _config["BaseURL"] + UrlStrings.CustomerCreateUrl;
            var post = _apiHandler.PostApi<Resultmodel<CustomerDto>>(customerDto, customerUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var url = _config["BaseURL"] + UrlStrings.CustomerGetUrl + "/" + id;
            var GetCustomer = _apiHandler.GetApi<Resultmodel<CustomerDto>>(url);
            return View(GetCustomer.Data);
        }
        [HttpPost]
        public IActionResult Update(CustomerDto customerDto)
        {
            var customerUrl = _config["BaseURL"] + UrlStrings.CustomerUpdateUrl;
            var post = _apiHandler.PostApi<Resultmodel<CustomerDto>>(customerDto, customerUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var url = _config["BaseURL"] + UrlStrings.CustomerRemoveUrl + "/" + id;
            var delete = _apiHandler.GetApi<Resultmodel<CustomerDto>>(url);
            return RedirectToAction("Index");
        }
        public async Task<JsonResult> TCValidate(long tc, string name, string surname, DateTime BirthDate)
        {
            var client = new TCService.KPSPublicSoapClient(TCService.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(tc), name, surname, BirthDate.Year);
            var result = response.Body.TCKimlikNoDogrulaResult;
            return Json(result);
        }
    }
}
