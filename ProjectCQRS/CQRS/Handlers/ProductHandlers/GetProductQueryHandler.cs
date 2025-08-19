using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Results.CategoryResults;
using ProjectCQRS.CQRS.Results.ProductResults;

namespace ProjectCQRS.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler(CQRSContext context)
    {
        private readonly CQRSContext _context = context;
        public async Task<List<GetProductQueryResult>> Handle()
        {
            var values = await _context.Products.ToListAsync();
            return values.Select(x => new GetProductQueryResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductStock = x.ProductStock,

            }).ToList();
        }


    }
}
