namespace NanoRpcSharp
{
    /// <summary>
    /// Base class for all requests (contain only <see cref="Action"/>).
    /// </summary>
    public abstract class RequestBase<TResponse>
    {
        public RequestBase(string action)
        {
            this.Action = action;
        }

        /// <summary>
        /// Action name (required).
        /// </summary>
        public string Action { get; protected set; }
    }
}
