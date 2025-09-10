using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.Context;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _StatisticComponent(CQRSContext ctx) : ViewComponent
    {
        private readonly CQRSContext _ctx = ctx;

        public IViewComponentResult Invoke()
        {
            var statistic_1 = _ctx.Cars.Count();
            var statistic_2 = _ctx.Brands.Where(x=>x.BrandID==8).Select(y=>y.Cars.Count()).FirstOrDefault();
            var statistic_3 = 15800;
            var statistic_4 = _ctx.Cars.Select(c => (decimal?)c.Price).Average() ?? 0m;

            ViewBag.statistic_1 = statistic_1;
            ViewBag.statistic_2 = statistic_2;
            ViewBag.statistic_3 = statistic_3;
            ViewBag.statistic_4 = (int)Math.Round(statistic_4);

            return View();
        }
    }
}
