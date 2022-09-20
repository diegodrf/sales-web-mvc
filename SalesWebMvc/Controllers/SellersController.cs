using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;

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
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var seller = _sellersService.FindById(id.Value);
            
            if (seller is null)
            {
                return NotFound();
            }
            return View(seller);
        }
        public IActionResult Delete(int? id)
        {
            
            if (id is null)
            {
                return NotFound();
            }
            var seller = _sellersService.FindById(id.Value);
            
            if (seller is null)
            {
                return NotFound();
            }
            return View(seller);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellersService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id:int}")]
        public IActionResult Edit(int id)
        {
            var seller = _sellersService.FindById(id);
            if (seller is null)
            {
                return NotFound();
            }

            var departments = _departmentsService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments, Seller = seller };

            return View(viewModel);
        }

        [HttpPost("{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            try
            {
                _sellersService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}