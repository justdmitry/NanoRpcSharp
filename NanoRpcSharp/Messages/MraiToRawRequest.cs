namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Multiply an Mrai amount by the Mrai ratio.
    /// </summary>
    public class MraiToRawRequest : RequestBase<BigIntegerAmount>
    {
        public MraiToRawRequest(BigInteger amount)
            : base("mrai_to_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
