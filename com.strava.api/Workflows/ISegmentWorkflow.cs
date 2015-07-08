using com.Strava.api.Representations;
using SwimBikeRun.Model.Segments;

namespace SwimBikeRun.Workflows
{
    public interface ISegmentWorkflow
    {
        OperationResponse<ISegment> GetById(int segmentId);
    }
}