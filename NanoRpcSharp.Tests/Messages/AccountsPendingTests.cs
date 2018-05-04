namespace NanoRpcSharp.Messages
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class AccountsPendingTests
    {
        [Fact]
        public void RequestOk()
        {
            var req = new AccountsPendingRequest(
                1,
                "xrb_1111111111111111111111111111111111111111111111111117353trpda",
                "xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""accounts_pending"",  
  ""accounts"": [""xrb_1111111111111111111111111111111111111111111111111117353trpda"", 
                 ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3""],  
  ""count"": 1
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void RequestWithAmountOk()
        {
            var req = new AccountsPendingWithAmountRequest(
                BigInteger.Parse("1000000000000000000000000"),
                1,
                "xrb_1111111111111111111111111111111111111111111111111117353trpda",
                "xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""accounts_pending"",  
  ""accounts"": [""xrb_1111111111111111111111111111111111111111111111111117353trpda"", 
                 ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3""],  
  ""count"": 1,
  ""threshold"" : ""1000000000000000000000000""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void RequestWithAmountSourceOk()
        {
            var req = new AccountsPendingWithAmountSourceRequest(
                BigInteger.Parse("1000000000000000000000000"),
                1,
                "xrb_1111111111111111111111111111111111111111111111111117353trpda",
                "xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3");
            var reqJson = NanoRpcClient.Serialize(req);

            var validJson = @"
{  
  ""action"": ""accounts_pending"",  
  ""accounts"": [""xrb_1111111111111111111111111111111111111111111111111117353trpda"", 
                 ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3""],  
  ""count"": 1,
  ""threshold"" : ""1000000000000000000000000"",
  ""source"" : ""true""
}
";

            Assert.True(JToken.DeepEquals(JObject.Parse(validJson), JObject.Parse(reqJson)));
        }

        [Fact]
        public void ResponseOk()
        {
            var validJson = @"
{  
  ""blocks"" : {  
    ""xrb_1111111111111111111111111111111111111111111111111117353trpda"": [""142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D""],  
    ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"": [""4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74""]
  }
}
";
            var obj = NanoRpcClient.Deserialize<AccountsPending>(validJson);

            Assert.Single(obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"]);
            Assert.Equal("142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D", obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"][0]);

            Assert.Single(obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]);
            Assert.Equal("4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74", obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"][0]);
        }

        [Fact]
        public void ResponseWithAmountOk()
        {
            var validJson = @"
{  
  ""blocks"" : {
    ""xrb_1111111111111111111111111111111111111111111111111117353trpda"": {
                ""142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D"": ""6000000000000000000000000000000""
    },    
    ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"": {
                ""4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74"": ""106370018000000000000000000000000""
    }
  }
}
";
            var obj = NanoRpcClient.Deserialize<AccountsPendingWithAmount>(validJson);

            Assert.NotNull(obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"]);
            Assert.Equal(
                BigInteger.Parse("6000000000000000000000000000000"),
                obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"]["142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D"]);

            Assert.NotNull(obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]);
            Assert.Equal(
                BigInteger.Parse("106370018000000000000000000000000"),
                obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]["4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74"]);
        }

        [Fact]
        public void ResponseWithAmountSourceOk()
        {
            var validJson = @"
{  
  ""blocks"" : {
    ""xrb_1111111111111111111111111111111111111111111111111117353trpda"": {
        ""142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D"": {
            ""amount"": ""6000000000000000000000000000000"",       
            ""source"": ""xrb_3dcfozsmekr1tr9skf1oa5wbgmxt81qepfdnt7zicq5x3hk65fg4fqj58mbr""
        }
    },    
    ""xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"": {
        ""4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74"": {
            ""amount"": ""106370018000000000000000000000000"",       
            ""source"": ""xrb_13ezf4od79h1tgj9aiu4djzcmmguendtjfuhwfukhuucboua8cpoihmh8byo""
        }
    }
  }
}
";
            var obj = NanoRpcClient.Deserialize<AccountsPendingWithAmountSource>(validJson);

            Assert.NotNull(obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"]);
            Assert.Equal(
                BigInteger.Parse("6000000000000000000000000000000"),
                obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"]["142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D"].Amount);
            Assert.Equal(
                "xrb_3dcfozsmekr1tr9skf1oa5wbgmxt81qepfdnt7zicq5x3hk65fg4fqj58mbr",
                obj.Blocks["xrb_1111111111111111111111111111111111111111111111111117353trpda"]["142A538F36833D1CC78B94E11C766F75818F8B940771335C6C1B8AB880C5BB1D"].Source);

            Assert.NotNull(obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]);
            Assert.Equal(
                BigInteger.Parse("106370018000000000000000000000000"),
                obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]["4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74"].Amount);
            Assert.Equal(
                "xrb_13ezf4od79h1tgj9aiu4djzcmmguendtjfuhwfukhuucboua8cpoihmh8byo",
                obj.Blocks["xrb_3t6k35gi95xu6tergt6p69ck76ogmitsa8mnijtpxm9fkcm736xtoncuohr3"]["4C1FEEF0BEA7F50BE35489A1233FE002B212DEA554B55B1B470D78BD8F210C74"].Source);
        }
    }
}