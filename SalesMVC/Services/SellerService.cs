using Microsoft.EntityFrameworkCore;
using MySqlConnector.Logging;
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
        #region Properties
        /// <summary>
        /// Context
        /// </summary>
        private readonly SalesMVCContext _context;
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor to init context
        /// </summary>
        /// <param name="context"></param>
        public SellerService(SalesMVCContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all sellers
        /// </summary>
        /// <returns>All sellers</returns>
        public List<Seller> GetSellers()
        {
            return _context.Seller.ToList();
        }

        /// <summary>
        /// Save seller
        /// </summary>
        /// <param name="seller">Seller to save</param>
        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Seller</returns>
        public Seller FindById(int id)
        {
            Seller seller = _context.Seller.Find(id);
            return seller;
        }

        /// <summary>
        /// Delete a seller by id
        /// </summary>
        /// <param name="id">Id to delete</param>
        public void Delete(int id)
        {

            _context.Remove(FindById(id));
            _context.SaveChanges();
        }
        #endregion
    }
}
