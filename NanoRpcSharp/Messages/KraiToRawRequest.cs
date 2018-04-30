namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Multiply an krai amount by the krai ratio.
    /// </summary>
    public class KraiToRawRequest : RequestBase<BigIntegerAmount>
    {
        public KraiToRawRequest(decimal amount)
            : base("krai_to_raw")
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
