using Microsoft.EntityFrameworkCore;
using SalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
                result = result.Where(salesRec => salesRec.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(salesRec => salesRec.Date <= maxDate.Value);

            return await result
                .Include(salesRec => salesRec.Seller)
                .Include(salesRec => salesRec.Seller.Department)
                .OrderByDescending(salesRec => salesRec.Date)
                .ToListAsync();
        }

        /// <summary>
        /// Find sales record by date
        /// </summary>
        /// <param name="minDate">Minimum date</param>
        /// <param name="maxDate">Maximum date</param>
        /// <returns>List of sales records grup by departments</returns>
        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            // transforms in object iqueryable
            var result = await FindByDateAsync(minDate, maxDate);

            return result.GroupBy(x => x.Seller.Department).ToList();
        }
        #endregion
    }
}
