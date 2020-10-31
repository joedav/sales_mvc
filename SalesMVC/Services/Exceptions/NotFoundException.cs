using System;

namespace SalesMVC.Services.Exceptions
{
    /// <summary>
    /// Exception notfound
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Pass message to superclass
        /// </summary>
        /// <param name="message">Message</param>
        public NotFoundException(string message) : base(message) { }
    }
}
