using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesMVC.Controllers
{
    /// <summary>
    /// Sales record controller
    /// </summary>
    public class SalesRecordController : Controller
    {
        /// <summary>
        /// View index of sales record
        /// </summary>
        /// <returns>Sales record</returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
