using Nancy;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Modules
{











    public class SegmentModule : NancyModule
    {
        private const string BaseEndpoint = @"/Segments";
        private readonly ISegmentWorkflow _segmentWorkflow;

        public SegmentModule(ISegmentWorkflow segmentWorkflow) : base(BaseEndpoint)
        {
            _segmentWorkflow = segmentWorkflow;

            Get["/{id:int}"] = GetSegment;
        }

        private dynamic GetSegment(dynamic parameters)
        {
            IOperationResponse<ISegment> operationResponse = _segmentWorkflow.GetById(parameters.Id);
            if (!operationResponse.OperationSucceeded) { return (HttpStatusCode) operationResponse.Status; }
            return Negotiate.Content(operationResponse);
        }
    }
}