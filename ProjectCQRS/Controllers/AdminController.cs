using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjectCQRS.CQRS.Commands.CarCommands;
using ProjectCQRS.CQRS.Commands.CategoryCommands;
using ProjectCQRS.CQRS.Commands.ContactCommands;
using ProjectCQRS.CQRS.Handlers.BrandHandlers;
using ProjectCQRS.CQRS.Handlers.CarHandlers;
using ProjectCQRS.CQRS.Handlers.CategoryHandlers;
using ProjectCQRS.CQRS.Handlers.ContactHandlers;
using ProjectCQRS.CQRS.Queries.CarQueries;
using ProjectCQRS.CQRS.Queries.CategoryQueries;
using ProjectCQRS.Entities;
using ProjectCQRS.Models;

namespace ProjectCQRS.Controllers
{
    public class AdminController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
        GetCategoryQueryHandler getCategoryQueryHandler,
        CreateCategoryCommandHandler createCategoryCommandHandler,
        UpdateCategoryCommandHandler updateCategoryCommandHandler,
        RemoveCategoryCommandHandler removeCategoryCommandHandler,
        GetCarByIdQueryHandler getCarByIdQueryHandler,
        GetCarQueryHandler getCarQueryHandler,
        CreateCarCommandHandler createCarCommandHandler,
        UpdateCarCommandHandler updateCarCommandHandler,
        RemoveCarCommandHandler removeCarCommandHandler,
        GetBrandByIdQueryHandler getBrandByIdQueryHandler,
        GetBrandQueryHandler getBrandQueryHandler,
        CreateBrandCommandHandler createBrandCommandHandler,
        UpdateBrandCommandHandler updateBrandCommandHandler,
        RemoveBrandCommandHandler removeBrandCommandHandler,
        CreateContactCommandHandler createContactCommandHandler,
        GetContactQueryHandler getContactQueryHandler,
        RemoveContactCommandHandler removeContactCommandHandler,
        SetContactReadStatusCommandHandler setContactReadStatusCommandHandler) : Controller
    {
        //category
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler = getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler = createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler = updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler = removeCategoryCommandHandler;
        //car
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler = getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler = getCarQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler = createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler = updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler = removeCarCommandHandler;

        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler = getBrandQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler = createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler = updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler = removeBrandCommandHandler;

        private readonly CreateContactCommandHandler _createContactCommandHandler = createContactCommandHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler = getContactQueryHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler = removeContactCommandHandler;
        private readonly SetContactReadStatusCommandHandler _setContactReadStatusCommandHandler= setContactReadStatusCommandHandler;


        public async Task<IActionResult> Dashboard()
        {

            //    var client = new HttpClient();
            //    var request = new HttpRequestMessage
            //    {
            //        Method = HttpMethod.Get,
            //        RequestUri = new Uri("https://gas-price.p.rapidapi.com/europeanCountries"),
            //        Headers =
            //        {
            //            { "x-rapidapi-key", "b9932ec3a5msh82539f9acf839e5p10b76cjsnd9ed723f6724" },
            //{ "x-rapidapi-host", "gas-price.p.rapidapi.com" },
            //        },
            //    };
            //    using (var response = await client.SendAsync(request))
            //    {
            //        response.EnsureSuccessStatusCode();
            //        var body = await response.Content.ReadAsStringAsync();

            //        var result = JsonConvert.DeserializeObject<GasPriceData>(body);
            //        List<GasPriceVM> apiVM = result.Result;
            //        return View(apiVM);
            //    }
            return View();
        }
        //---------------------------------------------------------------------------------category
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return RedirectToAction("CategoryList");
        }

        //-------------------------------------------------------------------------car

        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            var brands = await _getBrandQueryHandler.Handle();

            ViewBag.BrandList = brands.Select(x => new SelectListItem { Value = x.BrandID.ToString(), Text = x.Name }).ToList();

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return RedirectToAction("CarList");
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return RedirectToAction("CarList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return RedirectToAction("CarList");
        }


        //-------------------------------------------------------------------------contact!
        //Hem ui Hem de admin icin calisan bir yer!

        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return RedirectToAction("ContactList", "Admin");
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return RedirectToAction("ContactList");
        }
        [HttpPost]
        public async Task<IActionResult> ReadStatus(int id)
        {
            await _setContactReadStatusCommandHandler.Handle(new SetContactReadStatusCommand(id));
            return RedirectToAction("ContactList");
        }
    }
}
