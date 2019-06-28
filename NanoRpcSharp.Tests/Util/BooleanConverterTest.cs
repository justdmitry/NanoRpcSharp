namespace NanoRpcSharp.Util
{
    using Newtonsoft.Json;
    using Xunit;

    public class BooleanConverterTest
    {
        [Fact]
        public void ItWorks()
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new BooleanConverter());

            var json = @"
{
  ""val1"": ""true"",
  ""val2"": 'true',
  ""val3"": true,
  ""val4"": ""false"",
  ""val5"": 'false',
  ""val6"": false,
}
";
            var obj = JsonConvert.DeserializeObject<TestClass>(json, jsonSettings);
            Assert.True(obj.Val1);
            Assert.True(obj.Val2);
            Assert.True(obj.Val3);
            Assert.False(obj.Val4);
            Assert.False(obj.Val5);
            Assert.False(obj.Val6);
        }

        private class TestClass
        {
            public bool Val1 { get; set; }

            public bool Val2 { get; set; }

            public bool Val3 { get; set; }

            public bool Val4 { get; set; }

            public bool Val5 { get; set; }

            public bool Val6 { get; set; }
        }
    }
}