using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Results.BrandResults;

namespace ProjectCQRS.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values= await _context.Brands.ToListAsync();
            return values.Select(x => new GetBrandQueryResult
            {
                BrandID = x.BrandID,
                Name = x.Name
            }).ToList();
        }

    }
}
