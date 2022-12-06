using DTO;
using Microsoft.AspNetCore.Mvc;
using UI.ApiHandler;
using UI.Models;

namespace UI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IApiHandler _apiHandler;

        public BasketController(IApiHandler apiHandler, IConfiguration config)
        {
            _apiHandler = apiHandler;
            _config = config;
        }

        public IActionResult AddBasket(int productId)
        {
            var customerUrl = _config["BaseURL"] + UrlStrings.CustomerListUrl;
            var customerList = _apiHandler.GetApi<Resultmodel<CustomerDto>>(customerUrl);
            ViewBag.ProductId = productId;
            return View(customerList);
        }
        [HttpPost]
        public IActionResult AddBasket(BasketProcessDto basket)
        {
            var url = _config["BaseURL"] + UrlStrings.AddToBasket;
            var post=_apiHandler.PostApi<Resultmodel<BasketProcessDto>>(basket,url);
            return RedirectToAction("Index", "Product");
        }
        public IActionResult CustomerBasket(int customerId)
        {
            var url = _config["BaseURL"] + UrlStrings.BasketListByCustomer + "/" + customerId;
            var customerBasket = _apiHandler.GetApi<Resultmodel<BasketDto>>(url);

            var customerAddressUrl = _config["BaseURL"] + UrlStrings.AddressListUrl + "/" + customerId;
            var getAddress = _apiHandler.GetApi<Resultmodel<AddressDto>>(customerAddressUrl);

            BasketVM basket = new BasketVM()
            {
                addressDtos=getAddress.DataList,
                basketDtos=customerBasket.DataList
            };

            return View(basket);
        }
        public IActionResult CreateOrder(int customerId,int addressId,decimal totalPrice)
        {
            BasketProcessDto basketProcess = new BasketProcessDto()
            {
                CustomerId = customerId,
                AddressId = addressId,
                TotalPrice= totalPrice
            };
            var url = _config["BaseURL"] + UrlStrings.CreateOrder;
            var create = _apiHandler.PostApi<Resultmodel<OrderDto>>(basketProcess, url);
            return RedirectToAction("Index", "Customer");
        }
    }
}
