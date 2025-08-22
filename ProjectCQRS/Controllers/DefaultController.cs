using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
