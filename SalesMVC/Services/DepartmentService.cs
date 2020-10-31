using Microsoft.EntityFrameworkCore;
using SalesMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMVC.Services
{
    /// <summary>
    /// Department service
    /// </summary>
    public class DepartmentService
    {
        #region Properties
        /// <summary>
        /// Context
        /// </summary>
        private readonly SalesMVCContext _context;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor with context argument
        /// </summary>
        /// <param name="context"></param>
        public DepartmentService(SalesMVCContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Find all departments
        /// </summary>
        /// <returns>All de partments</returns>
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(d => d.Name).ToListAsync();
        }
        #endregion
    }
}
