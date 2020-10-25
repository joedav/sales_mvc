using Microsoft.EntityFrameworkCore;
using SalesMVC.Models;

namespace SalesMVC.Data
{
    /// <summary>
    /// Configuring dbcontext with models and dbsets
    /// </summary>
    public class SalesMVCContext : DbContext
    {
        /// <summary>
        /// Cosntructor
        /// </summary>
        /// <param name="options"></param>
        public SalesMVCContext(DbContextOptions<SalesMVCContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Dbset of department
        /// </summary>
        public DbSet<Department> Department { get; set; }

        /// <summary>
        /// Seller dbset
        /// </summary>
        public DbSet<Seller> Saller { get; set; }

        /// <summary>
        /// SalesRecod dbset
        /// </summary>
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
