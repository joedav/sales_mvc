using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_MVC.Models;

namespace Sales_MVC.Data
{
    public class Sales_MVCContext : DbContext
    {
        public Sales_MVCContext (DbContextOptions<Sales_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Sales_MVC.Models.Department> Department { get; set; }
    }
}
