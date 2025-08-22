using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _ServicesComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
