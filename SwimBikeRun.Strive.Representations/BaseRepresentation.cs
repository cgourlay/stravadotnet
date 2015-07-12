using System;

namespace SwimBikeRun.Strive.Representations
{
    public abstract class BaseRepresentation
    {
        public static Uri ApplicationNamespace = new Uri(@"http://schemas.swim-bike-run/strive");
        public static string DomainApplicationProtocolNamespace = @"http://schemas.swim-bike-run/strive/dap";
        public static string ApplicationMediaType = @"application/vnd.strive+json";
        public static string SelfRelationValue = @"self";
    }
}