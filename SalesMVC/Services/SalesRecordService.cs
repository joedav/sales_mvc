using Microsoft.EntityFrameworkCore;
using SalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMVC.Services
{
    /// <summary>
    /// Represents service of sales record
    /// </summary>
    public class SalesRecordService
    {
        #region Properties
        /// <summary>
        /// Context aplication
        /// </summary>
        private readonly SalesMVCContext _context;
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor expected received a context
        /// </summary>
        public SalesRecordService(SalesMVCContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Find sales record by date
        /// </summary>
        /// <param name="minDate">Minimum date</param>
        /// <param name="maxDate">Maximum date</param>
        /// <returns>List of sales records</returns>
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            // transforms in object iqueryable
            var res = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
                res = res.Where(salesRec => salesRec.Date >= minDate.Value);

            if (maxDate.HasValue)
                res = res.Where(salesRec => salesRec.Date <= maxDate.Value);

            return await res
                .Include(salesRec => salesRec.Seller)
                .Include(salesRec => salesRec.Seller.Department)
                .OrderByDescending(salesRec => salesRec.Date)
                .ToListAsync();
        }
        #endregion
    }
}
