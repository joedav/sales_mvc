using SalesMVC.Models;
using System.Collections.Generic;
using System.Linq;

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
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
        #endregion
    }
}
