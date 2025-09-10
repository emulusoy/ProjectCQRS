using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectCQRS.Context;
using ProjectCQRS.Models;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _ReservationComponent:ViewComponent
    {
        CQRSContext _ctx = new CQRSContext();

        public _ReservationComponent(CQRSContext context)
        {
            _ctx = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new ReservationBoxVM
            {
                CarNames = await _ctx.Cars.OrderBy(x => x.CarName).Select(x => x.CarName).Distinct().ToListAsync(),
                Cities = await _ctx.Cities.OrderBy(x => x.CityName).Select(x => x.CityName).ToListAsync()
            };

            // CarName -> { pricePerDay, imageUrl }
            var meta = await _ctx.Cars
                .GroupBy(c => c.CarName)
                .Select(g => new { Name = g.Key, Price = g.Min(x => x.Price), Img = g.Min(x => x.ImageUrl) })
                .ToDictionaryAsync(x => x.Name, x => new { pricePerDay = x.Price, imageUrl = x.Img });

            ViewBag.CarMetaJson = JsonSerializer.Serialize(meta); // VM'e dokunmadık.

            return View(vm);
        }
    }
}
