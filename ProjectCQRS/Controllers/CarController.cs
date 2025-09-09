using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.CQRS.Handlers.CarHandlers;


namespace ProjectCQRS.Controllers
{
    public class CarController : Controller
    {
        private readonly GetCarQueryHandler _getcarsQueryHandler;

        public CarController(GetCarQueryHandler getcarsQueryHandler)
        {
            _getcarsQueryHandler = getcarsQueryHandler;
        }

        public async Task<IActionResult>Index()
        {
            var values = await _getcarsQueryHandler.Handle();
            return View(values);
        }
    }
}
