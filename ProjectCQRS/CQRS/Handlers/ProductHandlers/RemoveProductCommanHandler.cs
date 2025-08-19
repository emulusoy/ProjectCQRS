using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ProductCommands;

namespace ProjectCQRS.CQRS.Handlers.ProductHandlers
{
    public class RemoveProductCommanHandler
    {
        private readonly CQRSContext _context;

        public RemoveProductCommanHandler(CQRSContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveProductCommand command)
        {
            var val = await _context.Products.FindAsync(command.ProductId);

                _context.Products.Remove(val);
                await _context.SaveChangesAsync();
            

        }
    }
}
