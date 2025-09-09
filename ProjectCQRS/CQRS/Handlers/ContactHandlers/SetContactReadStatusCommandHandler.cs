using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ContactCommands;

namespace ProjectCQRS.CQRS.Handlers.ContactHandlers
{
    public class SetContactReadStatusCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(SetContactReadStatusCommand command)
        {
            var find=await _context.Contacts.FindAsync(command.ContactId);
            if (find.IsRead==false)
            {
                find.IsRead = true;
            }
            else
            {
                find.IsRead = false;
            }
            await _context.SaveChangesAsync();

        }
    }
}
