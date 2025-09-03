using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.Context;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _ContactComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
