using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.CQRS.Commands.ProductCommands;
using ProjectCQRS.CQRS.Handlers.ProductHandlers;
using ProjectCQRS.CQRS.Queries.ProductQueries;

namespace ProjectCQRS.Controllers
{
    public class ProductController(
        GetProductQueryHandler getProductQueryHandler, 
        GetProductByIdQueryHandler getProductByIdQueryHandler, 
        CreateProductCommanHandler createProductCommandHandler, 
        UpdateProductCommanHandler updateProductCommandHandler, 
        RemoveProductCommanHandler removeProductCommanHandler) : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler = getProductQueryHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler = getProductByIdQueryHandler;
        private readonly CreateProductCommanHandler _createProductCommandHandler = createProductCommandHandler;
        private readonly UpdateProductCommanHandler _updateProductCommandHandler = updateProductCommandHandler;
        private readonly RemoveProductCommanHandler _removeProductCommanHandler = removeProductCommanHandler;

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ProductList()
        {
            var values = await _getProductQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _removeProductCommanHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }
    }
}
