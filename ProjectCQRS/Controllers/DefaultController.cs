using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.CQRS.Commands.ContactCommands;
using ProjectCQRS.CQRS.Handlers.ContactHandlers;

namespace ProjectCQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly CreateContactCommandHandler _handler;
        public DefaultController(CreateContactCommandHandler handler) => _handler = handler;
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactCommand command)
        {
            await _handler.Handle(command);         
            TempData["ContactSuccess"] = true;      
            return RedirectToAction(nameof(Index)); 
        }
    }
}
