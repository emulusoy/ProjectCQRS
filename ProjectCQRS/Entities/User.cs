namespace ProjectCQRS.Entities
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string? UserFoto { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
