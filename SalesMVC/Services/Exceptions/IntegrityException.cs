using System;

namespace SalesMVC.Services.Exceptions
{
    /// <summary>
    /// Class represents errors of referential integrity
    /// </summary>
    public class IntegrityException : ApplicationException
    {
        /// <summary>
        /// Constrcutor 
        /// </summary>
        /// <param name="message">Message</param>
        public IntegrityException(string message) : base(message) { }
    }
}
