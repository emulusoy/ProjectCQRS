using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ContactCommands;

namespace ProjectCQRS.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        public async Task Handle(RemoveContactCommand command)
        {
            var delete=await _context.Contacts.FindAsync(command.ContactId);
            _context.Contacts.Remove(delete);
            await _context.SaveChangesAsync();

        }
    }
}
