using com.strava.api.Dtos;
using com.strava.api.Model.Segments;

namespace com.strava.api.Handlers
{
    public interface ISegmentHandler
    {
        OperationResponse<ISegment> GetById(int segmentId);
    }
}