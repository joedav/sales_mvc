using Microsoft.EntityFrameworkCore;
using SalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMVC.Services
{
    /// <summary>
    /// Seller service
    /// </summary>
    public class SellerService
    {
        /// <summary>
        /// Context
        /// </summary>
        private readonly SalesMVCContext _context;

        /// <summary>
        /// Simple constructor to init context
        /// </summary>
        /// <param name="context"></param>
        public SellerService(SalesMVCContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all sellers
        /// </summary>
        /// <returns>All sellers</returns>
        public List<Seller> GetSellers()
        {
            return _context.Seller.ToList();
        }
    }
}
