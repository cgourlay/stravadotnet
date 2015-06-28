using com.strava.api.Representations;
using com.strava.api.Model.Segments;

namespace com.strava.api.Workflows
{
    public interface ISegmentWorkflow
    {
        OperationResponse<ISegment> GetById(int segmentId);
    }
}