namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class VersionTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new VersionRequest();
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""version"" 
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""rpc_version"" : ""1"",
  ""store_version"" : ""2"",
  ""node_vendor"" : ""RaiBlocks 7.5.0""
}
";
            var obj = NanoRpcClient.Deserialize<Version>(validJson);

            Assert.Equal("1", obj.RpcVersion);
            Assert.Equal("2", obj.StoreVersion);
            Assert.Equal("RaiBlocks 7.5.0", obj.NodeVendor);
        }
    }
}
