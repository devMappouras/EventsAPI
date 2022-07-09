using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
