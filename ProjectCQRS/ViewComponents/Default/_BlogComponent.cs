using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _BlogComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
