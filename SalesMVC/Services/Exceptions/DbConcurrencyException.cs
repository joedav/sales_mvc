using System;

namespace SalesMVC.Services.Exceptions
{
    /// <summary>
    /// Exception db Concurrency
    /// </summary>
    public class DbConcurrencyException : ApplicationException
    {
        /// <summary>
        /// Constructor to pass mesasge to superclass
        /// </summary>
        /// <param name="message">Message</param>
        public DbConcurrencyException(string message) : base(message) { }
    }
}
