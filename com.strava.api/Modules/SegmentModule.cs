using System;

using com.strava.api.Api;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Http;

using com.strava.api.Model.Segments;

namespace com.strava.api.Modules
{
    public class SegmentModule
    {
        public ISegment GetSegment(string segmentId, IAuthentication auth)
        {
            var json = WebRequest.SendGet(new Uri(string.Format("{0}/{1}?access_token={2}", Endpoints.Leaderboard, segmentId, auth.AccessToken)));
            return Unmarshaller<Segment>.Unmarshal(json);
        }
    }
}
