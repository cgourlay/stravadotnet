using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations;

namespace SwimBikeRun.Strive.Workflows
{
    public interface ISegmentWorkflow
    {
        OperationResponse<ISegment> GetById(int segmentId);
    }
}