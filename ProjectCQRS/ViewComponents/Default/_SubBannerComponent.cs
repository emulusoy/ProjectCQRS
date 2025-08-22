using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _SubBannerComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
