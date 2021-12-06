namespace vpos.seb.business.Payments
{
    /// <summary>
    /// Deposit operation.
    /// </summary>
    public class DepositOperation
    {
        public string AccountNumber { get; set; }
        public string PinCode { get; set; }
        public decimal DepositAmount { get; set; }
    }
}
