﻿namespace NanoRpcSharp
{
    using System;
    using Newtonsoft.Json;

    public class NullableBooleanConverter : JsonConverter<bool?>
    {
        public override bool? ReadJson(JsonReader reader, Type objectType, bool? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var val = default(bool?);

            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    val = null;
                    break;
                case JsonToken.String:
                    var str = (string)reader.Value;
                    val = bool.Parse(str);
                    break;
                case JsonToken.Boolean:
                    val = (bool)reader.Value;
                    break;
                default:
                    throw new JsonSerializationException($"Can't deserialize from TokenType={reader.TokenType}");
            }

            return val;
        }

        public override void WriteJson(JsonWriter writer, bool? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                writer.WriteValue(value.Value ? "true" : "false");
            }
        }
    }
}
