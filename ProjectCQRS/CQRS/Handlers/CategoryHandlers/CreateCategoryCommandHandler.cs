using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CategoryCommands;
using ProjectCQRS.Entities;

namespace ProjectCQRS.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler(CQRSContext context)

    {
        private readonly CQRSContext _context=context;

        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category 
            {
                CategoryName = command.CategoryName,
            });
            await _context.SaveChangesAsync();
        }
    }
}
