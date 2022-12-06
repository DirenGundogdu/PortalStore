using DTO;
using Microsoft.AspNetCore.Mvc;
using UI.ApiHandler;
using UI.Models;

namespace UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IApiHandler _apiHandler;

        public AddressController(IApiHandler apiHandler, IConfiguration config)
        {
            _apiHandler = apiHandler;
            _config = config;
        }
        public IActionResult Index(int customerId)
        {
            var url = _config["BaseURL"] + UrlStrings.AddressListUrl + "/" + customerId;
            var GetAddress = _apiHandler.GetApi<Resultmodel<AddressDto>>(url);
            ViewBag.customerId=customerId;
            return View(GetAddress);
        }

        public IActionResult Create(int customerId)
        {
            ViewBag.customerId = customerId;
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddressProcessDto addressDto)
        {
            var addressUrl = _config["BaseURL"] + UrlStrings.AddressCreateUrl;
            var post = _apiHandler.PostApi<Resultmodel<AddressProcessDto>>(addressDto, addressUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var url = _config["BaseURL"] + UrlStrings.AddressGetUrl + "/" + id;
            var GetAddress = _apiHandler.GetApi<Resultmodel<AddressProcessDto>>(url);
            return View(GetAddress.Data);
        }
        [HttpPost]
        public IActionResult Update(AddressProcessDto addressProcessDto)
        {
            var addressUrl = _config["BaseURL"] + UrlStrings.AddressUpdateUrl;
            var post = _apiHandler.PostApi<Resultmodel<AddressProcessDto>>(addressProcessDto, addressUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var addressUrl = _config["BaseURL"] + UrlStrings.AddressRemoveUrl + "/" + id;
            var delete = _apiHandler.GetApi<Resultmodel<AddressProcessDto>>(addressUrl);
            return RedirectToAction("Index","Customer");
        }



    }
}
