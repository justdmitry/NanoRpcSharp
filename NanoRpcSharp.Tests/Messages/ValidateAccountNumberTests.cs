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
            var req = new ValidateAccountNumberRequest("xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""validate_account_number"",
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
  ""valid"" : ""1""
}
";
            var obj = NanoRpcClient.Deserialize<ValidateAccountNumber>(validJson);

            Assert.Equal(1, obj.Valid);
        }
    }
}
