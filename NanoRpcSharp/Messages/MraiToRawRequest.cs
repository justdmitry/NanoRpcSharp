namespace NanoRpcSharp.Messages
{
    public class MraiToRawRequest : RequestBase<UInt256Amount>
    {
        public MraiToRawRequest(decimal amount)
            : base("mrai_to_raw")
        {
            this.Amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
