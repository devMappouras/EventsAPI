using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    public class OrganisersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
