namespace NanoRpcSharp
{
    using System;
    using System.Threading.Tasks;

    public interface INanoRpcClient
    {
        Task<TResponse> SendAsync<TResponse>(RequestBase<TResponse> request);
    }
}
