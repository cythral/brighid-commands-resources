using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Brighid.Commands.Resources
{
    /// <summary>
    /// Converter for converting bool values to json and vice versa.
    /// </summary>
    public class BoolValueConverter : JsonConverter<bool>
    {
        /// <inheritdoc />
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!.ToLower();
                return stringValue switch
                {
                    "true" => true,
                    "false" => false,
                    _ => throw new InvalidOperationException(),
                };
            }

            return reader.GetBoolean();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteBooleanValue(value);
        }
    }
}
