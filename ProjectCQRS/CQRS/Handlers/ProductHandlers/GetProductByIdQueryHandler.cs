using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Queries.CategoryQueries;
using ProjectCQRS.CQRS.Queries.ProductQueries;
using ProjectCQRS.CQRS.Results.CategoryResults;
using ProjectCQRS.CQRS.Results.ProductResults;

namespace ProjectCQRS.CQRS.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {
            var values = await _context.Products.FindAsync(query.Id);
            return new GetProductByIdQueryResult
            {
                ProductName = values.ProductName,
                ProductStock = values.ProductStock,
                ProductPrice = values.ProductPrice,
                ProductId = values.ProductId
            };
        }
    }
}
