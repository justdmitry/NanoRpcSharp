namespace NanoRpcSharp
{
    using System;
    using System.Globalization;
    using System.Numerics;
    using Newtonsoft.Json;

    public class BigIntegerConverter : JsonConverter<BigInteger>
    {
        public override BigInteger ReadJson(JsonReader reader, Type objectType, BigInteger existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var val = default(BigInteger);

            switch (reader.TokenType)
            {
                case JsonToken.String:
                    var str = (string)reader.Value;
                    val = BigInteger.Parse(str, CultureInfo.InvariantCulture);
                    break;
                case JsonToken.Integer:
                    var lng = (long)reader.Value;
                    val = new BigInteger(lng);
                    break;
                default:
                    throw new JsonSerializationException($"Can't deserialize from TokenType={reader.TokenType}");
            }

            // Does not allow negative values
            if (val.Sign == -1)
            {
                throw new Exception("Negative values are not allowed: " + val);
            }

            return val;
        }

        public override void WriteJson(JsonWriter writer, BigInteger value, JsonSerializer serializer)
        {
            var str = value.ToString("R", CultureInfo.InvariantCulture);

            // Does not allow negative values
            if (value.Sign == -1)
            {
                throw new Exception("Negative values are not allowed: " + str);
            }

            writer.WriteValue(str);
        }
    }
}
