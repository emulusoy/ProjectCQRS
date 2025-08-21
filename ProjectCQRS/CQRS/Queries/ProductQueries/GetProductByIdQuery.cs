namespace ProjectCQRS.CQRS.Queries.ProductQueries
{
    public class GetProductByIdQuery
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int id)
        {
            ProductId = id;
        }
    }
}
