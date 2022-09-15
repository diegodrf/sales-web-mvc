using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentsService _departmentsService;

        public SellersController(SellersService sellersService, DepartmentsService departmentsService)
        {
            _sellersService = sellersService;
            _departmentsService = departmentsService;
        }
        public IActionResult Index()
        {
            var list = _sellersService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        { var departments = _departmentsService.FindAll();
            var sellerFormViewModel = new SellerFormViewModel
            {
                Departments = departments
            };
            return View(sellerFormViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellersService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }
        public IActionResult Details()
        {
            throw new NotImplementedException();
        }
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}