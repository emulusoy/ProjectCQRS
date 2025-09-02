using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.BrandCommands;
using ProjectCQRS.Entities;

namespace ProjectCQRS.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(CreateBrandCommand command)
        {
            _context.Brands.Add(new Brand
            {
                Name = command.Name

            }); 
            await _context.SaveChangesAsync();
        }
    }
}
