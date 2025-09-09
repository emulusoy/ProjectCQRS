using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Queries.CarQueries;
using ProjectCQRS.CQRS.Results.CarResults;

namespace ProjectCQRS.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _context.Cars.FindAsync(query.CarId);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
                BrandID = values.Brand.BrandID,
                CarName = values.CarName,
                ReviewPoint = values.ReviewPoint,
                ImageUrl = values.ImageUrl,
                Price = values.Price,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Fuel = values.Fuel,
                ModelYear = values.ModelYear,
                Km = values.Km,
                Auto = values.Auto          
            };
        }
    }
}
