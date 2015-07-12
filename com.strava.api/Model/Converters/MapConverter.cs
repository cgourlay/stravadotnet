using System;

using Newtonsoft.Json;

using com.Strava.Api.Activities;
using SwimBikeRun.Strive.Model.Interfaces.Activities;

namespace com.Strava.Api.Model.Converters
{
    public class MapConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IMap);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(Map));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}