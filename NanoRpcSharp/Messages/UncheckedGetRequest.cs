namespace NanoRpcSharp.Messages
{
    /// <summary>
    /// Retrieves a json representation of unchecked synchronizing block by hash.
    /// </summary>
    /// <remarks>
    /// Return <b>null</b> when block not found.
    /// </remarks>
    public class UncheckedGetRequest : RequestBase<UncheckedGet>
    {
        public UncheckedGetRequest(Hex32 hash)
            : base("unchecked_get")
        {
            this.Hash = hash;
            this.WellKnownErrors = ErrorsBlockNotFound;
        }

        public Hex32 Hash { get; set; }
    }
}
