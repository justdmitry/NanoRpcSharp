namespace NanoRpcSharp.Messages
{
    using System;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountsFrontiersTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountsFrontiersRequest(
                "xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3",
                "xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""accounts_frontiers"",  
  ""accounts"": [""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"", ""xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7""]
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""frontiers"" : {  
    ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"": ""791AF413173EEE674A6FCF633B5DFC0F3C33F397F0DA08E987D9E0741D40D81A"",  
    ""xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7"": ""6A32397F4E95AF025DE29D9BF1ACE864D5404362258E06489FABDBA9DCCC046F""
  }
}
";
            var obj = NanoRpcClient.Deserialize<AccountsFrontiers>(validJson);

            Assert.Equal("791AF413173EEE674A6FCF633B5DFC0F3C33F397F0DA08E987D9E0741D40D81A", obj.Frontiers["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]);

            Assert.Equal("6A32397F4E95AF025DE29D9BF1ACE864D5404362258E06489FABDBA9DCCC046F", obj.Frontiers["xrb_3i1aq1cchnmbn9x5rsbap8b15akfh7wj7pwskuzi7ahz8oq6cobd99d4r3b7"]);
        }
    }
}
