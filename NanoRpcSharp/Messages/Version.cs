namespace NanoRpcSharp.Messages
{
    using System;

    public class Version
    {
        private string nodeVendorValue;

        public string RpcVersion { get; set; }

        public string StoreVersion { get; set; }

        public string NodeVendor
        {
            get
            {
                return nodeVendorValue;
            }

            set
            {
                nodeVendorValue = value;

                NetworkType = NetworkType.Unknown;

                if (!string.IsNullOrWhiteSpace(NodeVendor))
                {
                    if (NodeVendor.StartsWith("Nano ", StringComparison.OrdinalIgnoreCase))
                    {
                        NetworkType = NetworkType.Nano;
                    }

                    if (NodeVendor.StartsWith("Banano ", StringComparison.OrdinalIgnoreCase))
                    {
                        NetworkType = NetworkType.Banano;
                    }
                }
            }
        }

        public NetworkType NetworkType { get; private set; }
    }
}
