using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
