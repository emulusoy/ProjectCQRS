using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Results.CategoryResults;

namespace ProjectCQRS.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values=await _context.Categories.ToListAsync();
            return values.Select(x=> new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }
        



    }
}
