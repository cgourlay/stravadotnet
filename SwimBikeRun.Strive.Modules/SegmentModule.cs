using Nancy;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Modules.Helpers;
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
            return response.OperationSucceeded ? Negotiate.Content(response) : (dynamic)(HttpStatusCode)response.Status;
        }

        private dynamic GetSegment(dynamic parameters)
        {
            IOperationResponse<ISegment> response = _segmentWorkflow.GetById(parameters.Id);
            return response.OperationSucceeded ? Negotiate.Content(response) : (dynamic)(HttpStatusCode)response.Status;
        }
    }
}