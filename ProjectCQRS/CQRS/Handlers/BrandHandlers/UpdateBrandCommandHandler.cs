using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.BrandCommands;

namespace ProjectCQRS.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await _context.Brands.FindAsync(command.BrandID);
            values.BrandID = command.BrandID;
            values.Name = command.Name;
            await _context.SaveChangesAsync();
        }
    }
}
