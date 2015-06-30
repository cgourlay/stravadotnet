using System.Collections.Generic;
using System.IO;

using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.strava.api.Helpers
{
    public sealed class JsonNetSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        public JsonNetSerializer()
        {
            _serializer = JsonSerializer.Create(new JsonSerializerSettings());
            _serializer.Converters.Add(new StringEnumConverter());
            _serializer.Converters.Add(new BinaryConverter());
        }

        public bool CanSerialize(string contentType)
        {
            return contentType == Representations.BaseRepresentation.ApplicationMediaType;
        }

        public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
        {
            using (var writer = new JsonTextWriter(new StreamWriter(outputStream)))
            {
                _serializer.Serialize(writer, model);
                writer.Flush();
            }
        }

        public IEnumerable<string> Extensions
        {
            get { return new List<string>(); }
        }
    }
}
