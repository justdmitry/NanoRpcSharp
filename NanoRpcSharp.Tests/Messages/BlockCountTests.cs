namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class BlockCountTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new BlockCountRequest();
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""block_count"",  
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""count"": ""1000"",  
  ""unchecked"": ""10""
}
";
            var obj = NanoRpcClient.Deserialize<BlockCount>(validJson);

            Assert.Equal(1000, obj.Count);
            Assert.Equal(10, obj.Unchecked);
        }
    }
}
