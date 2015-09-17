using System.Globalization;

using Nancy;
using Nancy.Responses.Negotiation;
using SwimBikeRun.Strive.Model.Interfaces;
using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;

namespace SwimBikeRun.Strive.Modules.Helpers
{
    public static class NegotiatorExtensions
    {
        public static Negotiator Content(this Negotiator negotiator, IOperationResponse<ILeaderboard> operationResponse)
        {
            return negotiator.WithEtagHeader(operationResponse)
                             //.WithLocationHeader(operationResponse)
                             .WithStatusCode((HttpStatusCode)operationResponse.Status)
                             .ForJson(operationResponse);
        }

        private static Negotiator ForJson(this Negotiator negotiator, IOperationResponse<ILeaderboard> model)
        {
            return negotiator.WithMediaRangeModel(new MediaRange("application/json"), (Response)model.DataAsJson());
        }

        private static Negotiator WithEtagHeader(this Negotiator negotiator, IOperationResponse<ILeaderboard> operationResponse)
        {
            return negotiator.WithHeader("ETag", string.Format("\"{0}\"", operationResponse.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
        }

        private static Negotiator WithLocationHeader(this Negotiator negotiator, IOperationResponse<ILeaderboard> operationResponse)
        {
            //return negotiator.WithHeader("Location", string.Format(@"{0}/{1}", negotiator.NegotiationContext.ModulePath, operationResponse.Data.Id));
            return null; // a leaderboard does not have an id.
        }








        public static Negotiator Content(this Negotiator negotiator, IOperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithEtagHeader(operationResponse)
                             .WithLocationHeader(operationResponse)
                             .WithStatusCode((HttpStatusCode)operationResponse.Status)
                             .ForJson(operationResponse);
        }

        private static Negotiator ForJson(this Negotiator negotiator, IOperationResponse<ISegment> model)
        {
            return negotiator.WithMediaRangeModel(new MediaRange("application/json"), (Response)model.DataAsJson());
        }

        private static Negotiator WithEtagHeader(this Negotiator negotiator, IOperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithHeader("ETag", string.Format("\"{0}\"", operationResponse.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
        }

        private static Negotiator WithLocationHeader(this Negotiator negotiator, IOperationResponse<ISegment> operationResponse)
        {
            return negotiator.WithHeader("Location", string.Format(@"{0}/{1}", negotiator.NegotiationContext.ModulePath, operationResponse.Data.Id));
        }
    }   
}