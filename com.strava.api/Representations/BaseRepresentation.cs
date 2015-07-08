using System;

namespace SwimBikeRun.Representations
{
    public abstract class BaseRepresentation
    {
        public static Uri ApplicationNamespace = new Uri(@"http://schemas.swim-bike-run/tavla");
        public static string DomainApplicationProtocolNamespace = @"http://schemas.swim-bike-run/tavla/dap";
        public static string ApplicationMediaType = @"application/vnd.tavla+json";
        public static string SelfRelationValue = @"self";
    }
}