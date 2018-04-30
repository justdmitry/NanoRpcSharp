namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Multiply an Mrai amount by the Mrai ratio.
    /// </summary>
    public class MraiToRawRequest : RequestBase<BigIntegerAmount>
    {
        public MraiToRawRequest(decimal amount)
            : base("mrai_to_raw")
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
