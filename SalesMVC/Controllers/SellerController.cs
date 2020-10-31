using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Models.ViewModel;
using SalesMVC.Models.ViewModels;
using SalesMVC.Services;
using SalesMVC.Services.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace SalesMVC.Controllers
{
    /// <summary>
    /// Saller controller
    /// </summary>
    public class SellerController : Controller
    {
        #region Properties
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        #endregion

        #region Constructors
        public SellerController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>Index</returns>
        public IActionResult Index()
        {
            var sellers = _sellerService.FindAll();
            return View(sellers);
        }

        /// <summary>
        /// View create
        /// </summary>
        /// <returns>View create</returns>
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var sellerViewModel = new SellerFormViewModel { Departments = departments };
            return View(sellerViewModel);
        }

        /// <summary>
        /// Save new Saller in db
        /// </summary>
        /// <param name="seller">New obj seller</param>
        /// <returns>Index</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// View Edit seller
        /// </summary>
        /// <param name="id">id of seller</param>
        /// <returns>View edit seller</returns>
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided." });

            var seller = _sellerService.FindById(id.Value);

            if (seller is null)
                return RedirectToAction(nameof(Error), new { message = "Seller not found in database." });

            List<Department> departments = _departmentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };


            _sellerService.Update(seller);
            return View(viewModel);
        }

        /// <summary>
        /// Method to update seller
        /// </summary>
        /// <param name="seller">Seller to update</param>
        /// <returns>View with updated seller</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
                return RedirectToAction(nameof(Error), new { message = "Ids mismatch!" });

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException notFoundEx)
            {
                return RedirectToAction(nameof(Error), new { message = notFoundEx.Message });
            }
            catch (DbConcurrencyException dbConcurrencyEx)
            {
                return RedirectToAction(nameof(Error), new { message = dbConcurrencyEx.Message });
            }
        }

        /// <summary>
        /// Delete a seller
        /// </summary>
        /// <param name="id">Id of seller to delete</param>
        /// <returns>Redirect to action index</returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Invalid ID to delete." });

            var model = _sellerService.FindById(id.Value);

            if (model == null)
                return RedirectToAction(nameof(Error), new { message = "Seler not found." });

            return View("Delete", model);
        }

        /// <summary>
        /// Delete an seller by id
        /// </summary>
        /// <param name="id">Id of seller to delete</param>
        /// <returns>List View</returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _sellerService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _sellerService.FindById(id);

            if (model is null)
                return RedirectToAction(nameof(Error), new { message = "Seller not found!" });

            return View(model);
        }

        /// <summary>
        /// Error view
        /// </summary>
        /// <param name="message">Message to show</param>
        /// <returns>View with error</returns>
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier // HttpContext.TraceIdentifier - returns internal id request
            };
            return View(viewModel);
        }
        #endregion
    }
}
