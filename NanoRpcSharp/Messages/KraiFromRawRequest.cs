namespace NanoRpcSharp.Messages
{
    public class KraiFromRawRequest : RequestBase<DecimalAmount>
    {
        public KraiFromRawRequest(UInt256 amount)
            : base("krai_from_raw")
        {
            this.Amount = amount;
        }

        public UInt256 Amount { get; set; }
    }
}
