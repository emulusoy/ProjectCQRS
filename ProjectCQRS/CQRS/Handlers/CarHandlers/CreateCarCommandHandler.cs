using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CarCommands;
using ProjectCQRS.Entities;

namespace ProjectCQRS.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        public async Task Handle(CreateCarCommand command)
        {
            _context.Cars.Add(new Car
            {
                CarName = command.CarName,
                BrandID = command.BrandID,
                ReviewPoint = command.ReviewPoint,
                ImageUrl = command.ImageUrl,
                Price = command.Price,
                Km = command.Km,
                Transmission = command.Transmission,
                Seat = command.Seat,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                ModelYear = command.ModelYear,
                Auto = command.Auto
                
            }); await _context.SaveChangesAsync();
        }
    }
}
