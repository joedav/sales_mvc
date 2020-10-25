using SalesMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SalesMVC.Models
{
    /// <summary>
    /// Class represents a saller
    /// </summary>
    public class Seller
    {
        #region Properties
        /// <summary>
        /// Id, number control
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of saller
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email of saller
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Birth date of saller
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Salary base of saller
        /// </summary>
        public double BaseSalary { get; set; }

        /// <summary>
        /// Department
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Sales
        /// </summary>
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor without arguments
        /// </summary>
        public Seller() { }

        /// <summary>
        /// Constructor with arguments
        /// </summary>
        /// <param name="id">Number of control</param>
        /// <param name="name">Name of saller</param>
        /// <param name="email">Email saller</param>
        /// <param name="birthDate">BirthDate saller</param>
        /// <param name="baseSalary">ase salary</param>
        /// <param name="department">Department</param>
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add sales records in conllection
        /// </summary>
        /// <param name="salesRecord">Sales record</param>
        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        /// <summary>
        /// Remove sales in collection
        /// </summary>
        /// <param name="salesRecord">Sales record</param>
        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        /// <summary>
        /// Total sales
        /// </summary>
        /// <param name="initial">Initial date</param>
        /// <param name="final">Final date</param>
        /// <returns>The sum of the value at that given time</returns>
        public double TotalSales(DateTime initial, DateTime final)
        {
            double totalValue = Sales.Where(sales => sales.Date >= initial && sales.Date <= final).Sum(sales => sales.Amount);

            return totalValue;
        }
        #endregion
    }
}
