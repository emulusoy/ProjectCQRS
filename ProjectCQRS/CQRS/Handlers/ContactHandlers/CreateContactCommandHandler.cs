using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ContactCommands;

namespace ProjectCQRS.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(CreateContactCommand command)
        {
            _context.Contacts.Add(new Entities.Contact
            {
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Project = command.Project,
                Subject = command.Subject,
                Message = command.Message,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            });
            await _context.SaveChangesAsync();
        }
    }
}
