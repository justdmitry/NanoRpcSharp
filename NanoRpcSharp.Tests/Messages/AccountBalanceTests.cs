﻿namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountBalanceTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountBalanceRequest("xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""account_balance"",
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
  ""balance"": 10000,  
  ""pending"": ""20000000000000000000000000000000000""
}
";
            var obj = NanoRpcClient.Deserialize<AccountBalance>(validJson);

            Assert.Equal(new BigInteger(10000), obj.Balance);
            Assert.Equal(BigInteger.Parse("20000000000000000000000000000000000"), obj.Pending);
        }
    }
}
