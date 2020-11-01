using SalesMVC.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesMVC.Models
{
    /// <summary>
    /// Class represents Sales record
    /// </summary>
    public class SalesRecord
    {
        #region Properties
        /// <summary>
        /// Id, number control
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Value amount
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:f2}")]
        public double Amount { get; set; }

        /// <summary>
        /// Status of sales record
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Seller
        /// </summary>
        public Seller Seller { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Simple constructor without arguments
        /// </summary>
        public SalesRecord() { }

        /// <summary>
        /// Cosntrucor with parameters
        /// </summary>
        /// <param name="id">Id, number control</param>
        /// <param name="date">Date of recort</param>
        /// <param name="amount">value</param>
        /// <param name="status">status of sale</param>
        /// <param name="seller">saller</param>
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
        #endregion
    }
}
