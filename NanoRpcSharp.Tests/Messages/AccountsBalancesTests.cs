namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountsBalancesTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountsBalancesRequest(
                "xrb_1111111111111111111111111111111111111111111111111111hifc8npp",
                "xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{
  ""action"": ""accounts_balances"",
  ""accounts"": [""xrb_1111111111111111111111111111111111111111111111111111hifc8npp"", ""xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7""]
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{
  ""balances"" : {
        ""xrb_1111111111111111111111111111111111111111111111111111hifc8npp"":
        {
            ""balance"": ""10000"",
            ""pending"": ""10000""
        },
        ""xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7"":
        {
            ""balance"": ""10000000"",
            ""pending"": ""0""
        }
    }
}
";
            var obj = NanoRpcClient.Deserialize<AccountsBalances>(validJson);

            Assert.True(obj.Balances.ContainsKey("xrb_1111111111111111111111111111111111111111111111111111hifc8npp"));
            Assert.Equal(10000, obj.Balances["xrb_1111111111111111111111111111111111111111111111111111hifc8npp"].Balance);
            Assert.Equal(10000, obj.Balances["xrb_1111111111111111111111111111111111111111111111111111hifc8npp"].Pending);

            Assert.True(obj.Balances.ContainsKey("xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7"));
            Assert.Equal(10000000, obj.Balances["xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7"].Balance);
            Assert.Equal(0, obj.Balances["xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7"].Pending);
        }
    }
}
