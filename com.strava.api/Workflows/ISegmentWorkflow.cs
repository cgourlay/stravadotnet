using com.Strava.api.Representations;
using com.Strava.api.Model.Segments;

namespace com.Strava.api.Workflows
{
    public interface ISegmentWorkflow
    {
        OperationResponse<ISegment> GetById(int segmentId);
    }
}