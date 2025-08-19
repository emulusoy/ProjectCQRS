using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Queries.CategoryQueries;
using ProjectCQRS.CQRS.Results.CategoryResults;

namespace ProjectCQRS.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context=context;

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryName = values.CategoryName
            };
        }
    }

}
