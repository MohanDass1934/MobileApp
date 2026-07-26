using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class MyDateTimeConverter : JsonConverter<DateTime>
{
    private static readonly string[] Formats =
    {
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-ddTHH:mm:ssZ"
    };

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return DateTime.MinValue;

        var value = reader.GetString();

        if (string.IsNullOrWhiteSpace(value))
            return DateTime.MinValue;

        if (DateTime.TryParseExact(
                value,
                Formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var date))
        {
            return date;
        }

        if (DateTime.TryParse(value, out date))
            return date;

        return DateTime.MinValue;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}

public class MyNullableDateTimeConverter : JsonConverter<DateTime?>
{
    private static readonly string[] Formats =
    {
        "yyyy-MM-dd HH:mm:ss",
        "yyyy-MM-dd",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-ddTHH:mm:ssZ"
    };

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        var value = reader.GetString();

        if (string.IsNullOrWhiteSpace(value))
            return null;

        if (DateTime.TryParseExact(
                value,
                Formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var date))
        {
            return date;
        }

        if (DateTime.TryParse(value, out date))
            return date;

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        else
            writer.WriteNullValue();
    }
}