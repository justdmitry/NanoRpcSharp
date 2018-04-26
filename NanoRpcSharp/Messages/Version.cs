namespace NanoRpcSharp.Messages
{
    public class Version
    {
        public short RpcVersion { get; set; }

        public short StoreVersion { get; set; }

        public string NodeVendor { get; set; }
    }
}
