namespace ProjectCQRS.Entities
{
    public class Car
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public double ReviewPoint { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Transmission { get; set; }
        public string Seat { get; set; }
        public string Luggage { get; set; }
        public string Fuel { get; set; }
        public string ModelYear { get; set; }
        public int Km { get; set; }
        public string Auto { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
