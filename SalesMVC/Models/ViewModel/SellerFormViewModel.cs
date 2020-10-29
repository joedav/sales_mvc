using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMVC.Models.ViewModel
{
    /// <summary>
    /// View model for aditional sallers information
    /// </summary>
    public class SellerFormViewModel
    {
        #region Properties
        /// <summary>
        /// Seller
        /// </summary>
        public Seller Seller { get; set; }

        /// <summary>
        /// Conllection for departments
        /// </summary>
        public ICollection<Department> Departments { get; set; }
        #endregion
    }
}
