namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class DelegatorsTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new DelegatorsRequest("nano_1111111111111111111111111111111111111111111111111117353trpda");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""delegators"",
  ""account"": ""nano_1111111111111111111111111111111111111111111111111117353trpda""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""delegators"": {
    ""nano_13bqhi1cdqq8yb9szneoc38qk899d58i5rcrgdk5mkdm86hekpoez3zxw5sd"": ""500000000000000000000000000000000000"",
    ""nano_17k6ug685154an8gri9whhe5kb5z1mf5w6y39gokc1657sh95fegm8ht1zpn"": ""961647970820730000000000000000000000""
  }
}
";
            var obj = NanoRpcClient.Deserialize<Delegators>(validJson);

            Assert.NotNull(obj.DelegatorList);
            Assert.Equal(2, obj.DelegatorList.Count);
            Assert.True(obj.DelegatorList.ContainsKey("nano_13bqhi1cdqq8yb9szneoc38qk899d58i5rcrgdk5mkdm86hekpoez3zxw5sd"));
            Assert.True(obj.DelegatorList.ContainsKey("nano_17k6ug685154an8gri9whhe5kb5z1mf5w6y39gokc1657sh95fegm8ht1zpn"));
            Assert.Equal(BigInteger.Parse("500000000000000000000000000000000000"), obj.DelegatorList["nano_13bqhi1cdqq8yb9szneoc38qk899d58i5rcrgdk5mkdm86hekpoez3zxw5sd"]);
            Assert.Equal(BigInteger.Parse("961647970820730000000000000000000000"), obj.DelegatorList["nano_17k6ug685154an8gri9whhe5kb5z1mf5w6y39gokc1657sh95fegm8ht1zpn"]);
        }
    }
}
