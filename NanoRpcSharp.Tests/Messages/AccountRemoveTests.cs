namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountRemoveTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountRemoveRequest(
                "000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F",
                "xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_remove"",  
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",  
  ""account"" : ""xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""removed"" : ""1""
}
";
            var obj = NanoRpcClient.Deserialize<AccountRemove>(validJson);

            Assert.Equal(1, obj.Removed);
        }
    }
}
