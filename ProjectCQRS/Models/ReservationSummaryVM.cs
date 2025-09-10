namespace ProjectCQRS.Models
{
    public class ReviewItemVM
    {
        public string Comment { get; set; } = "";
        public int Point { get; set; }
        public string UserDisplay { get; set; } = "";
    }
    public class ReservationSummaryVM
    {
        public string Pickup { get; set; } = "";
        public string Dropoff { get; set; } = "";
        public string CarName { get; set; } = "";

        public double DistanceKm { get; set; }
        public double DurationHours { get; set; }
        public double AvgConsumptionLPer100Km { get; set; }
        public double FuelNeededLiters { get; set; }

        public int Days { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal RentalCost => PricePerDay * Days;

        public string ImageUrl { get; set; } = "/cqrsrent/img/car-1.jpg";

        public decimal FuelPricePerLiterTRY { get; set; } 
        public decimal FuelCostTRY => (decimal)FuelNeededLiters * FuelPricePerLiterTRY;

        public decimal TotalSelectedDaysTRY => RentalCost + FuelCostTRY;
        public decimal TotalFiveDaysTRY => (PricePerDay * 5) + FuelCostTRY;
        public List<ReviewItemVM> Reviews { get; set; } = new();
        public double AveragePoint { get; set; }  // 0–5
        public int ReviewCount => Reviews?.Count ?? 0;
    }
   
}
