namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns version information for RPC, Store & Node (Major & Minor version)
    /// </summary>
    public class VersionRequest : RequestBase<Version>
    {
        public VersionRequest()
            : base("version")
        {
            // Nothing
        }
    }
}
