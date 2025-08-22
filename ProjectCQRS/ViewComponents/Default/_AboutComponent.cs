using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _AboutComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
