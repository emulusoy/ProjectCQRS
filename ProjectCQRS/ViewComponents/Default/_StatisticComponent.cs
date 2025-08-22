using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _StatisticComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
