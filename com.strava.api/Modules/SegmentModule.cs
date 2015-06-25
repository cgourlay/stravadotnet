using System;
using System.Globalization;

using Nancy;

using com.strava.api.Api;
using com.strava.api.Authentication;
using com.strava.api.Common;
using com.strava.api.Dtos;
using com.strava.api.Handlers;
using com.strava.api.Http;
using com.strava.api.Model.Segments;

namespace com.strava.api.Modules
{
    public class SegmentModule : NancyModule
    {
        private const string BaseEndpoint = @"/Segments";
        private readonly ISegmentHandler _segmentHandler;

        public SegmentModule(ISegmentHandler segmentHandler) : base(BaseEndpoint)
        {
            _segmentHandler = segmentHandler;

            Get["/{id:int}"] = GetSegment;
        }

        public ISegment GetSegment(string segmentId, IAuthentication auth)
        {
            var json = WebRequest.SendGet(new Uri(string.Format("{0}/{1}?access_token={2}", Endpoints.Leaderboard, segmentId, auth.AccessToken)));
            return Unmarshaller<Segment>.Unmarshal(json);
        }

        private dynamic GetSegment(dynamic parameters)
        {
            OperationResponse<ISegment> operationResponse = _segmentHandler.GetById(parameters.Id);
            if (!operationResponse.OperationSucceeded) { return (HttpStatusCode) operationResponse.Status; }
            return Negotiate.WithHeader("ETag", string.Format("\"{0}\"", operationResponse.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)))
                            .WithHeader("Location", string.Format(@"{0}/{1}", BaseEndpoint, operationResponse.Data.Id))
                            .WithStatusCode((HttpStatusCode)operationResponse.Status)
                            .WithModel(operationResponse.Data);
        }
    }
}