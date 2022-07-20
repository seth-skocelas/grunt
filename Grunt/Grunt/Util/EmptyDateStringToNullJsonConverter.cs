using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Grunt.Util
{
    /// <summary>
    /// Converts an empty date string to a null. 343i is returning some ISO8601 dates that we wrap in <see cref="Grunt.Models.APIFormattedDate"/> as empty,
    /// which in turn breaks System.Text.Json deserialization.
    /// </summary>
    internal class EmptyDateStringToNullJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();
            return string.IsNullOrWhiteSpace(value) ? null : DateTime.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
