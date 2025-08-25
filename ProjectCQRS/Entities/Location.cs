namespace ProjectCQRS.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string CityName { get; set; }
        public List<Reservation> PickUpReservation { get; set; }
        public List<Reservation> DropOffReservation { get; set; }
    }
}
