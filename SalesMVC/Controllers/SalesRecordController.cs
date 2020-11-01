using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesMVC.Services;

namespace SalesMVC.Controllers
{
    /// <summary>
    /// Sales record controller
    /// </summary>
    public class SalesRecordController : Controller
    {
        #region Properties
        /// <summary>
        /// Sales service
        /// </summary>
        private readonly SalesRecordService _salesRecService;
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor expecteds received sales record service
        /// </summary>
        /// <param name="salesRecordService">Sales record service</param>
        public SalesRecordController(SalesRecordService salesRecordService)
        {
            _salesRecService = salesRecordService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// View index of sales record
        /// </summary>
        /// <returns>Sales record</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get simplesearch by date
        /// </summary>
        /// <param name="minDate">Minimum date</param>
        /// <param name="maxDate">Maximum date</param>
        /// <returns>Filtered simple search</returns>
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = new DateTime(DateTime.Now.Year, 1, 1);

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var salesRecords = await _salesRecService.FindByDateAsync(minDate, maxDate);
            return View(salesRecords);
        }

        /// <summary>
        /// Get simplesearch by date
        /// </summary>
        /// <param name="minDate">Minimum date</param>
        /// <param name="maxDate">Maximum date</param>
        /// <returns>Filtered simple search</returns>
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = new DateTime(DateTime.Now.Year, 1, 1);
            if (!maxDate.HasValue) maxDate = DateTime.Now;

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var salesRecords = await _salesRecService.FindByDateGroupingAsync(minDate, maxDate);
            return View(salesRecords);
        }
        #endregion
    }
}
