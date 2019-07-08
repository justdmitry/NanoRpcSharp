namespace NanoRpcSharp
{
    public enum NetworkType : byte
    {
        /// <summary>
        /// Type of current node/network is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Current node/network type is Nano (mainnet or betanet).
        /// </summary>
        Nano = 1,

        /// <summary>
        /// Current node/network type is Banano.
        /// </summary>
        Banano = 19,
    }
}
