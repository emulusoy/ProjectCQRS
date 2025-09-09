using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Queries.BrandQueries;
using ProjectCQRS.CQRS.Queries.CarQueries;
using ProjectCQRS.CQRS.Results.BrandResults;

namespace ProjectCQRS.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var values = await _context.Brands.FindAsync(query.BrandID);
            return new GetBrandByIdQueryResult
            {
                BrandID = values.BrandID,
                Name = values.Name
            };
        }
    }
}
