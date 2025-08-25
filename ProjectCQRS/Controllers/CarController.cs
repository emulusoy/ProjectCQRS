using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
