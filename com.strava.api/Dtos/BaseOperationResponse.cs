using System;

namespace com.strava.api.Dtos
{
    public abstract class BaseOperationResponse
    {
        public static Uri ApplicationNamespace = new Uri(@"http://schemas.tavla.api");
        public static string DomainApplicationProtocolNamespace = @"dap";
        public static string ApplicationMediaType = @"application/vnd.tavla+json";
        public static string SelfRelationValue = @"self";
    }
}
