using System;

namespace SwimBikeRun.Strive.Representations
{
    public abstract class BaseRepresentation
    {
        public static readonly string ApplicationMediaType = @"application/vnd.strive+json";
        public static readonly Uri ApplicationNamespace = new Uri(@"http://schemas.swim-bike-run/strive");
        public static readonly string DomainApplicationProtocolNamespace = @"http://schemas.swim-bike-run/strive/dap";
        public static readonly string SelfRelationValue = @"self";
    }
}