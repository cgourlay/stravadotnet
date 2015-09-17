using System;

using Newtonsoft.Json;

namespace SwimBikeRun.Strive.Model.Converters
{
    public class UriConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return reader.TokenType == JsonToken.String ? new Uri((string)reader.Value) : null;
            }
            catch (UriFormatException)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value as Uri != null)
            {
                writer.WriteValue(((Uri)value).OriginalString);
                return;
            }

            writer.WriteNull();
        }
    }
}
