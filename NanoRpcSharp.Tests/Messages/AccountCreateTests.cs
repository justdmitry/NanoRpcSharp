namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountCreateTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountCreateRequest("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""account_create"",
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void RequestNoWorkOk()
        {
            var req = new AccountCreateRequest("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F")
            {
                Work = false,
            };

            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_create"",
  ""wallet"": ""000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F"",
  ""work"": ""false""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""account"" : ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp""
}
";
            var obj = NanoRpcClient.Deserialize<AccountCreate>(validJson);

            Assert.Equal("xrb_1111111111111111111111111111111111111111111111111111hifc8npp", obj.Account);
        }
    }
}
