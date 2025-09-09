using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CategoryCommands;

namespace ProjectCQRS.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            
        }
    }
}
