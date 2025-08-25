namespace ProjectCQRS.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }
        public int UserID { get; set; } 
        public User User { get; set; }
        public Car Car { get; set; }
        public int CarID { get; set; }
    }
}
