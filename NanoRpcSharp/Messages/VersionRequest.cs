namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Returns version information for RPC, Store & Node (Major & Minor version)
    /// </summary>
    /// <remarks>
    /// RPC Version always retruns "1" as of 13/01/2018
    /// </remarks>
    public class VersionRequest : RequestBase<Version>
    {
        public VersionRequest()
            : base("version")
        {
            // Nothing
        }
    }
}
