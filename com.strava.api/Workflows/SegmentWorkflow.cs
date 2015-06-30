using System;
using com.strava.api.Api;
using com.strava.api.Common;
using com.strava.api.Representations;
using com.strava.api.Http;
using com.strava.api.Model.Segments;

namespace com.strava.api.Workflows
{
    public class SegmentWorkflow : ISegmentWorkflow
    {
        public OperationResponse<ISegment> GetById(int segmentId)
        {
            var json = WebRequest.SendGet(new Uri(string.Format("{0}/{1}?access_token={2}", Endpoints.Leaderboard, segmentId, "pull the auth.AccessToken from somewhere")));
            return new OperationResponse<ISegment>() { Data = Unmarshaller.Unmarshal<Segment>(json), Status = OperationStatus.Ok };
        }
    }
}
