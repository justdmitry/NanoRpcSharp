namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class ValidateAccountNumberTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new ValidateAccountNumberRequest("xrb_1111111111111111111111111111111111111111111111111111hifc8npp");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""validate_account_number"",
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
  ""valid"" : ""1""
}
";
            var obj = NanoRpcClient.Deserialize<ValidateAccountNumber>(validJson);

            Assert.Equal(1, obj.Valid);
        }
    }
}
