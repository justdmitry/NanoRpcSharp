﻿namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class BanToRawTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new BanToRawRequest(BigInteger.One);
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""ban_to_raw"",
  ""amount"": ""1""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""amount"": ""1000000000000000000000000000""
}
";
            var obj = NanoRpcClient.Deserialize<BigIntegerAmount>(validJson);

            Assert.Equal(BigInteger.Parse("1000000000000000000000000000"), obj.Amount);
        }
    }
}
