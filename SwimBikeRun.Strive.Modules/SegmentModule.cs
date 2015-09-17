using System.Globalization;

using Nancy;
using Nancy.Responses.Negotiation;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Modules
{
    public class SegmentModule : SecureModule
    {
        private readonly ISegmentWorkflow _segmentWorkflow;

        public SegmentModule(ISegmentWorkflow segmentWorkflow)
        {
            _segmentWorkflow = segmentWorkflow;
            Get["/segments/{id:int}"] = GetSegment;
            Get["/segments/{id:int}/leaderboard"] = GetLeaderboard;
        }

        private dynamic GetLeaderboard(dynamic parameters)
        {
            IOperationResponse<ILeaderboard> response = _segmentWorkflow.GetSegmentLeaderboard(parameters.Id);
            if (response.OperationSucceeded)
            {
                return Negotiate.WithMediaRangeModel(new MediaRange("application/json"), (Response)response.DataAsJson())
                                .WithStatusCode((HttpStatusCode)response.Status)
                                .WithHeader("ETag", string.Format("\"{0}\"", response.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
            }
            
            return (dynamic)(HttpStatusCode)response.Status;
        }

        private dynamic GetSegment(dynamic parameters)
        {
            IOperationResponse<ISegment> response = _segmentWorkflow.GetById(parameters.Id);
            if (response.OperationSucceeded)
            {
                return Negotiate.WithMediaRangeModel(new MediaRange("application/json"), (Response)response.DataAsJson())
                                .WithStatusCode((HttpStatusCode)response.Status)
                                .WithHeader("Location", string.Format(@"{0}/{1}", Negotiate.NegotiationContext.ModulePath, response.Data.Id))
                                .WithHeader("ETag", string.Format("\"{0}\"", response.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
            }
            
            return (dynamic)(HttpStatusCode)response.Status;
        }
    }
}