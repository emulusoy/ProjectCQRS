using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.CarCommands;

namespace ProjectCQRS.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task Handle(UpdateCarCommand command)
        {
            var car = await _context.Cars.FindAsync(command.CarID);
            car.CarID=command.CarID;
            car.BrandID=command.BrandID;
            car.CarName=command.CarName;
            car.ModelYear=command.ModelYear;    
            car.Price=command.Price;
            car.ImageUrl=command.ImageUrl;
            car.Transmission=command.Transmission;
            car.Km=command.Km;
            car.Auto=command.Auto;
            car.Fuel=command.Fuel;
            car.Luggage=command.Luggage;
            car.Seat=command.Seat;
            car.ReviewPoint=command.ReviewPoint;
            await _context.SaveChangesAsync();
        }
    }
}
