using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    public class SectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
