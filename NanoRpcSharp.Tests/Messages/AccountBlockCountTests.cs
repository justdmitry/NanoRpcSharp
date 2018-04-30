namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountBlockCountTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountBlockCountRequest("xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_block_count"",
  ""account"": ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""block_count"" : ""19""
}
";
            var obj = NanoRpcClient.Deserialize<AccountBlockCount>(validJson);

            Assert.Equal(19, obj.BlockCount);
        }

        [Fact]
        public void ResponseNoQuotesOk()
        {
            var validJson = @"
{  
  ""block_count"" : 19
}
";
            var obj = NanoRpcClient.Deserialize<AccountBlockCount>(validJson);

            Assert.Equal(19, obj.BlockCount);
        }
    }
}
