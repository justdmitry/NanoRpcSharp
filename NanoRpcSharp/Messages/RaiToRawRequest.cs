namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Multiply an rai amount by the rai ratio.
    /// </summary>
    public class RaiToRawRequest : RequestBase<BigIntegerAmount>
    {
        public RaiToRawRequest(decimal amount)
            : base("rai_to_raw")
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
