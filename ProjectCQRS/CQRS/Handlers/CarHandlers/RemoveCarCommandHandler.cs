using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CarCommands;

namespace ProjectCQRS.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context=context;
        public async Task Handle(RemoveCarCommand command)
        {
            var values = await _context.Cars.FindAsync(command.CarID);
            _context.Cars.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
