using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Abstractions;
using ProjectCQRS.Context;
using ProjectCQRS.Models;

namespace ProjectCQRS.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IConfiguration _cfg;
        private readonly CQRSContext _ctx;
        public ReservationController(IConfiguration cfg, CQRSContext ctx)
        { _cfg = cfg; _ctx = ctx; }

        [HttpGet]
        public async Task<IActionResult> Summary(string pickup, string dropoff, string car, DateTime? pickupDate, DateTime? dropoffDate)
        {
            if (string.IsNullOrWhiteSpace(pickup) || string.IsNullOrWhiteSpace(dropoff) || string.IsNullOrWhiteSpace(car))
                return Redirect("/");

            var d1 = (pickupDate ?? DateTime.Today).Date;
            var d2 = (dropoffDate ?? DateTime.Today.AddDays(1)).Date;
            var days = Math.Max(1, (int)Math.Ceiling((d2 - d1).TotalDays));

  
            var carInfo = await _ctx.Cars
    .Where(x => x.CarName == car)
    .OrderBy(x => x.Price)
    .Select(x => new { x.CarID, x.Price, x.ImageUrl })
    .FirstOrDefaultAsync();

            var carId = carInfo?.CarID ?? 0;
            var pricePerDay = carInfo?.Price ?? 0m;
            var img = string.IsNullOrWhiteSpace(carInfo?.ImageUrl) ? "/cqrsrent/img/car-1.jpg" : carInfo!.ImageUrl;

            var key = _cfg["GEMINI_API_KEY"] ?? "";
            var est = await GeminiReservationInfo.EstimateAsync(key, pickup, dropoff, car);

            var fromCfg = _cfg["FUEL_TRY_PER_LITER_SEP2025"];
            decimal fuelPrice = 53.00m;
            if (decimal.TryParse(fromCfg, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var cfgVal))
                fuelPrice = cfgVal;
            var reviews = await _ctx.Reviews
            .Where(r => r.CarID == carId)
            .OrderByDescending(r => r.ReviewID)
            .Select(r => new ReviewItemVM
            {
                Comment = r.Comment,
                Point = r.Point,
                UserDisplay = r.User != null ? r.User.Name : ("Kullanıcı #" + r.UserID)
            })
            .ToListAsync();
            double avg = 0;
            if (reviews.Count > 0)
            {
                avg = reviews.Average(x =>
                {
                    var p = x.Point;
                    if (p < 0) p = 0; if (p > 5) p = 5;
                    return p;
                });
            }
            var vm = new ReservationSummaryVM
            {
                Pickup = pickup,
                Dropoff = dropoff,
                CarName = car,
                DistanceKm = est.distance_km,
                DurationHours = est.duration_hours,
                AvgConsumptionLPer100Km = est.avg_consumption_l_100km,
                FuelNeededLiters = est.fuel_needed_liters,
                Days = days,
                PricePerDay = pricePerDay,
                ImageUrl = img,
                FuelPricePerLiterTRY = fuelPrice, // daha önce eklediğimiz alan
                Reviews = reviews,
                AveragePoint = avg
            };

            return View(vm);
        }
    }
}
