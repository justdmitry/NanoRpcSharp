namespace NanoRpcSharp
{
    using System;
    using Newtonsoft.Json;

    public class UnixDateTimeConverter : JsonConverter
    {
        private static readonly DateTimeOffset ZeroDateTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var s = (string)reader.Value;
            var l = long.Parse(s);
            return ZeroDateTime.AddSeconds(l).ToLocalTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dt = (DateTimeOffset)value;
            var seconds = (long)dt.Subtract(ZeroDateTime).TotalSeconds;
            writer.WriteValue(seconds.ToString());
        }
    }
}
