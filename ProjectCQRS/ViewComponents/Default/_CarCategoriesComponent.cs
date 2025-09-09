using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Handlers.CarHandlers;
using ProjectCQRS.CQRS.Results.CarResults;

namespace ProjectCQRS.ViewComponents.Default
{
    public class _CarCategoriesComponent:ViewComponent
    {
        private readonly GetCarQueryHandler _getCarQueryHandle;

        public _CarCategoriesComponent(GetCarQueryHandler getCarQueryHandle)
        {
            _getCarQueryHandle = getCarQueryHandle;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _getCarQueryHandle.Handle();
            return View(values);
        }
    }
}
