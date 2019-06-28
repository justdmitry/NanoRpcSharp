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
            var req = new AccountWeightRequest("xrb_1111111111111111111111111111111111111111111111111111hifc8npp");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_weight"",
  ""account"": ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp""
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
