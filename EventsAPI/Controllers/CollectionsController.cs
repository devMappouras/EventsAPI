using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    public class CollectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
