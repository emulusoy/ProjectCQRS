namespace ProjectCQRS.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery(int brandID)
    {
        public int BrandID { get; set; } = brandID;
    }
}
