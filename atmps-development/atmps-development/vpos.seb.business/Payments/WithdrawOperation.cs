namespace vpos.seb.business.Payments
{
    /// <summary>
    /// Withdraw operation.
    /// </summary>
    public class WithdrawOperation
    {
        public string AccountNumber { get; set; }
        public string PinCode { get; set; }
        public decimal WithdrawAmount { get; set; }
    }
}
