namespace NanoRpcSharp.Messages
{
    public class Version
    {
        public string RpcVersion { get; set; }

        public string StoreVersion { get; set; }

        public string NodeVendor { get; set; }
    }
}
