namespace NanoRpcSharp
{
    /// <summary>
    /// Base class for all requests (contain only <see cref="Action"/>).
    /// </summary>
    public abstract class RequestBase<TResponse>
    {
        protected static readonly string[] ErrorsBlockNotFound = new[] { "Block not found" };

        public RequestBase(string action)
        {
            this.Action = action;
        }

        /// <summary>
        /// Action name (required).
        /// </summary>
        public string Action { get; protected set; }

        /// <summary>
        /// List of well-known errors, which should NOT cause exception (<b>null</b> will be returned instead).
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string[] WellKnownErrors { get; protected set; }
    }
}
