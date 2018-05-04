namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountWeightTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountWeightRequest("xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_weight"",  
  ""account"": ""xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""weight"" : ""10000""
}
";
            var obj = NanoRpcClient.Deserialize<AccountWeight>(validJson);

            Assert.Equal(10000, obj.Weight);
        }
    }
}
