using System;

namespace com.strava.api.Representations
{
    public abstract class BaseRepresentation
    {
        public static Uri ApplicationNamespace = new Uri(@"http://schemas.swim-bike-run.api/tavla");
        public static string DomainApplicationProtocolNamespace = @"http://schemas.swim-bike-run.api/tavla/dap";
        public static string ApplicationMediaType = @"application/vnd.swim-bike-run-tavla+json";
        public static string SelfRelationValue = @"self";
    }
}