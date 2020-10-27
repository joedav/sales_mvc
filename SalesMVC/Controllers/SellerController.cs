using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Action index
        /// </summary>
        /// <returns>Index</returns>
        public IActionResult Index()
        {
            var sellers = _sellerService.GetSellers();
            return View(sellers);
        }
    }
}
