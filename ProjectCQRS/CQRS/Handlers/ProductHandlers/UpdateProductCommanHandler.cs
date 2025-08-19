using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ProductCommands;

namespace ProjectCQRS.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommanHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(UpdateProductCommand command)
        {
            var product = await _context.Products.FindAsync(command.ProductId);

                product.ProductName = command.ProductName;
                product.ProductStock = command.ProductStock;
                product.ProductPrice = command.ProductPrice;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            
        }

    }
}
