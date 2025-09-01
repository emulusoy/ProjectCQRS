using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Results.CarResults;

namespace ProjectCQRS.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _context.Cars.ToListAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarID = x.CarID,
                CarName = x.CarName,
                BrandID = x.BrandID,
                ModelYear = x.ModelYear,
                Auto = x.Auto,
                Price = x.Price,
                Fuel = x.Fuel,
                ImageUrl = x.ImageUrl,
                Km = x.Km,
                Luggage = x.Luggage,
                ReviewPoint = x.ReviewPoint,
                Seat = x.Seat,
                Transmission= x.Transmission,
                

            }).ToList();
        }
    }
}
