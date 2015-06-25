using com.strava.api.Api;
using com.strava.api.Common;
using com.strava.api.Dtos;
using com.strava.api.Http;
using com.strava.api.Model.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.strava.api.Handlers
{
    public class SegmentHandler : ISegmentHandler
    {
        public OperationResponse<ISegment> GetById(int segmentId)
        {
            var json = WebRequest.SendGet(new Uri(string.Format("{0}/{1}?access_token={2}", Endpoints.Leaderboard, segmentId, "pull the auth.AccessToken from somewhere")));
            return new OperationResponse<ISegment>() { Data = Unmarshaller<Segment>.Unmarshal(json), Status = OperationStatus.Ok };
        }
    }
}
