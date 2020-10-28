using Microsoft.AspNetCore.Mvc;
using SalesMVC.Models;
using SalesMVC.Services;

namespace SalesMVC.Controllers
{
    /// <summary>
    /// Saller controller
    /// </summary>
    public class SellerController : Controller
    {
        #region Properties
        private readonly SellerService _sellerService;
        #endregion

        #region Constructors
        public SellerController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>Index</returns>
        public IActionResult Index()
        {
            var sellers = _sellerService.GetSellers();
            return View(sellers);
        }

        /// <summary>
        /// View create
        /// </summary>
        /// <returns>View create</returns>
        public IActionResult Create()
        {
            return View();
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

        public IActionResult Delete(int id)
        {
            _sellerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
