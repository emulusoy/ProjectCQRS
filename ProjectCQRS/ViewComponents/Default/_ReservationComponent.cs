using Microsoft.AspNetCore.Mvc;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _ReservationComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
