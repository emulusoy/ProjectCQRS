using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CategoryCommands;
using ProjectCQRS.CQRS.Commands.ProductCommands;
using ProjectCQRS.Entities;

namespace ProjectCQRS.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommanHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        public async Task Handle(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                ProductName = command.ProductName,
                ProductStock = command.ProductStock,
                ProductPrice = command.ProductPrice,
            });
            await _context.SaveChangesAsync();
        }
    }
}
