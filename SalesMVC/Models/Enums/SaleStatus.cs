namespace SalesMVC.Models.Enums
{
    /// <summary>
    /// Enum Sale Status
    /// </summary>
    public enum SaleStatus : int
    {
        /// <summary>
        /// Status Pending
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Status Billed
        /// </summary>
        Billed = 1,

        /// <summary>
        /// Status Canceled
        /// </summary>
        Canceled = 2
    }
}
