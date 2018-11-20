namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;

    public class SendRequest : RequestBase<Send>
    {
        public SendRequest(Hex32 wallet, Account source, Account destination, BigInteger amount, string id, string work = null)
            : base("send")
        {
            this.Wallet = wallet;
            this.Source = source;
            this.Destination = destination;
            this.Amount = amount;
            this.Id = id;
            this.Work = work;
        }

        public Hex32 Wallet { get; set; }

        public Account Source { get; set; }

        public Account Destination { get; set; }

        public BigInteger Amount { get; set; }

        public string Id { get; set; }

        public string Work { get; set; }
    }
}
