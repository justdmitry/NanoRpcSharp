namespace NanoRpcSharp.Messages
{
    using System.Numerics;

    /// <summary>
    /// Convert nano amount (10^30 raw) into raw (10^0).
    /// </summary>
    public class NanoToRawRequest : RequestBase<BigIntegerAmount>
    {
        public NanoToRawRequest(BigInteger amount)
            : base("nano_to_raw")
        {
            this.Amount = amount;
        }

        public BigInteger Amount { get; set; }
    }
}
