using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.strava.api.Model.Converters
{
    public abstract class JsonArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type @type)
        {
            return typeof(T).IsAssignableFrom(@type);
        }

        protected abstract T Create(Type @type, JArray json);

        public override object ReadJson(JsonReader reader, Type @type, object existingValue, JsonSerializer serializer)
        {
            return Create(@type, JArray.Load(reader));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
