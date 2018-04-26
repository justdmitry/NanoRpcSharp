namespace NanoRpcSharp
{
    using System;
    using System.Numerics;
    using Newtonsoft.Json;

    public class UInt256Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UInt256);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var t = (string)reader.Value;
            return new UInt256(BigInteger.Parse("0" + t));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var val = (UInt256)value;
            writer.WriteValue(val.ToBigInteger().ToString());
        }
    }
}
