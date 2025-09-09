using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.BrandCommands;

namespace ProjectCQRS.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(RemoveBrandCommand command)
        {
            var values = await _context.Brands.FindAsync(command.BrandID);
            _context.Brands.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
