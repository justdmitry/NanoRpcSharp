namespace NanoRpcSharp.Messages
{
    using System.Collections.Generic;
    using System.Numerics;
    using Newtonsoft.Json;

    public class Delegators
    {
        [JsonProperty("delegators")]
        public Dictionary<Account, BigInteger> DelegatorList { get; set; }
    }
}
