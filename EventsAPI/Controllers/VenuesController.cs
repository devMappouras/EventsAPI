using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    public class VenuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
