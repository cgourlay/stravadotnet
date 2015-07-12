using SwimBikeRun.Representations;
using SwimBikeRun.Model.Segments;
using SwimBikeRun.Strive.Model.Interfaces.Segments;

namespace SwimBikeRun.Workflows
{
    public interface ISegmentWorkflow
    {
        OperationResponse<ISegment> GetById(int segmentId);
    }
}