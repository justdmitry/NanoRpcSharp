namespace NanoRpcSharp.Messages
{
    public class MraiFromRawRequest : RequestBase<DecimalAmount>
    {
        public MraiFromRawRequest(UInt256 amount)
            : base("mrai_from_raw")
        {
            this.Amount = amount;
        }

        public UInt256 Amount { get; set; }
    }
}
