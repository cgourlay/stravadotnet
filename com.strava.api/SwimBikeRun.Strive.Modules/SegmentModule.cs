using Nancy;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Modules.Helpers;
using SwimBikeRun.Strive.Representations.Interfaces;



















using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Modules
{
    public class SegmentModule : NancyModule
    {
        private readonly ISegmentWorkflow _segmentWorkflow;

        public SegmentModule(ISegmentWorkflow segmentWorkflow) : base(@"/Segments")
        {
            _segmentWorkflow = segmentWorkflow;

            Get["/{id:int}"] = GetSegment;
        }

        private dynamic GetSegment(dynamic parameters)
        {
            IOperationResponse<ISegment> response = _segmentWorkflow.GetById(parameters.Id);
            return response.OperationSucceeded ? Negotiate.Content(response) : (dynamic) (HttpStatusCode) response.Status;
        }
    }
}