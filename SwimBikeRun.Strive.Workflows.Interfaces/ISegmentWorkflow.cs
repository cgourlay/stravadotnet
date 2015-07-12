using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;

namespace SwimBikeRun.Strive.Workflows.Interfaces
{
    public interface ISegmentWorkflow
    {
        IOperationResponse<ISegment> GetById(int segmentId);
    }
}