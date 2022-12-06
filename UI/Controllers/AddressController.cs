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
            var addressUrl = _config["BaseURL"] + UrlStrings.AddressListUrl;
            var GetAddress = _apiHandler.GetApi<Resultmodel<AddressDto>>(addressUrl);

            return View(GetAddress.DataList);
        }

   

    }
}
