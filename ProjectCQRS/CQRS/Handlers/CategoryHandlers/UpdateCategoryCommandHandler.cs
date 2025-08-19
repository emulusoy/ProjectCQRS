using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CategoryCommands;

namespace ProjectCQRS.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            category.CategoryName = command.CategoryName;
 //               _context.Categories.Update(category);
                await _context.SaveChangesAsync();

        }

    }
}
