using System.Globalization;

using Nancy;
using Nancy.Responses.Negotiation;

using com.strava.api.Model.Segments;
using com.strava.api.Representations;

namespace com.strava.api.Helpers.Nancy
{
    public static class NegotiateExtensions
    {
        public static Negotiator Content(this Negotiator negotiator, OperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithEtagHeader(operationResponse)
                             .WithLocationHeader(operationResponse)
                             .WithStatusCode((HttpStatusCode)operationResponse.Status)
                             .ForJson(operationResponse);
        }

        private static Negotiator ForJson(this Negotiator negotiator, object model)
        {
            return negotiator.WithMediaRangeModel(new MediaRange("application/json"), model);
        }

        private static Negotiator WithEtagHeader(this Negotiator negotiator, OperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithHeader("ETag", string.Format("\"{0}\"", operationResponse.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
        }

        private static Negotiator WithLocationHeader(this Negotiator negotiator, OperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithHeader("Location", string.Format(@"{0}/{1}", negotiator.NegotiationContext.ModulePath, operationResponse.Data.Id));
        }
    }   
}
