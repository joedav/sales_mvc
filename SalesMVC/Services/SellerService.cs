using Microsoft.EntityFrameworkCore;
using SalesMVC.Models;
using SalesMVC.Services.Exceptions;
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
        public async Task<List<Seller>> FindAllAsync()
        {
            var sellers = await _context.Seller.Include(seller => seller.Department).ToListAsync();
            return sellers;
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Seller</returns>
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(seller => seller.Department).FirstOrDefaultAsync(seller => seller.Id == id);
        }

        /// <summary>
        /// Save seller
        /// </summary>
        /// <param name="seller">Seller to save</param>
        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update seller
        /// </summary>
        /// <param name="seller">Seller</param>
        public async Task UpdateAsync(Seller seller)
        {
            bool has = await _context.Seller.AnyAsync(s => s.Id == seller.Id);
            if (!has)
                throw new NotFoundException($"Seller not found!");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        /// <summary>
        /// Delete a seller by id
        /// </summary>
        /// <param name="id">Id to delete</param>
        public async Task DeleteAsync(int id)
        {
            var seller = await FindByIdAsync(id);
            _context.Remove(seller);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
