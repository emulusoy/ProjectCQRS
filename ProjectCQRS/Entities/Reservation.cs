namespace ProjectCQRS.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int? PickUpLocationID { get; set; }
        public int? DropOffLocationID { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropOffLocation { get; set; }

    }
}
