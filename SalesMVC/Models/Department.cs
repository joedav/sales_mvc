using SalesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesMVC.Models
{
    /// <summary>
    /// Class that represents a department
    /// </summary>
    public class Department
    {
        #region Properties
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sallers
        /// </summary>
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor without arguments
        /// </summary>
        public Department() { }

        /// <summary>
        /// Constructor with arguments
        /// </summary>
        /// <param name="id">Number of control</param>
        /// <param name="name">Name of department</param>
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add saller
        /// </summary>
        /// <param name="seller">Seller</param>
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        /// <summary>
        /// Total sales of department
        /// </summary>
        /// <param name="initial">Initial date</param>
        /// <param name="final">Final date</param>
        /// <returns>Amount value of total sales of this department</returns>
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
        #endregion
    }
}