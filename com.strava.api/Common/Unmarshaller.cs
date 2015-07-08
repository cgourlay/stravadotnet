using System;

using Newtonsoft.Json;

namespace com.strava.api.Common
{
    internal static class Unmarshaller
    {
        public static T Unmarshal<T>(string json)
        {
            if (string.IsNullOrEmpty(json)) { throw new ArgumentException("The json string is null or empty.","json"); }
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
