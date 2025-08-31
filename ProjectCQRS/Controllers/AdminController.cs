using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.CQRS.Commands.CategoryCommands;
using ProjectCQRS.CQRS.Handlers.CategoryHandlers;
using ProjectCQRS.CQRS.Queries.CategoryQueries;

namespace ProjectCQRS.Controllers
{
    public class AdminController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler) : Controller
    {
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler = getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler = createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler = updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler = removeCategoryCommandHandler;

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryList");
        }
    }
}
