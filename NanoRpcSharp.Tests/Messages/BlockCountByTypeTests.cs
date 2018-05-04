namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class BlockCountByTypeTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new BlockCountByTypeRequest();
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""block_count_type"",  
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
    ""send"": ""1000"",   
    ""receive"": ""900"",   
    ""open"": ""100"",   
    ""change"": ""50""  
}
";
            var obj = NanoRpcClient.Deserialize<BlockCountByType>(validJson);

            Assert.Equal(1000, obj.Send);
            Assert.Equal(900, obj.Receive);
            Assert.Equal(100, obj.Open);
            Assert.Equal(50, obj.Change);
        }
    }
}
