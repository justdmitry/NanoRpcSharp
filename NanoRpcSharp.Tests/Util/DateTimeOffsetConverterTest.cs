namespace NanoRpcSharp.Util
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json;
    using Xunit;

    public class DateTimeOffsetConverterTest
    {
        [Fact]
        public void ItWorks()
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new DateTimeOffsetConverter());

            var json = @"
{
    ""val1"": ""1501793775"",
}
";
            var obj = JsonConvert.DeserializeObject<TestClass>(json, jsonSettings);
            Assert.Equal(new DateTimeOffset(2017, 8, 3, 20, 56, 15, TimeSpan.Zero), obj.Val1);
        }

        private class TestClass
        {
            public DateTimeOffset Val1 { get; set; }
        }
    }
}