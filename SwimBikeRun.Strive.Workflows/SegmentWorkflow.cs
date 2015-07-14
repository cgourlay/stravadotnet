using System;
using System.Threading;







using com.Strava.Api.Api;
using com.Strava.Api.Common;
using com.Strava.Api.Http;
using com.Strava.Api.Repositories;
using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Model.Segments;
using SwimBikeRun.Strive.Repositories;
using SwimBikeRun.Strive.Representations;
using SwimBikeRun.Strive.Representations.Enums;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Workflows
{
    public class SegmentWorkflow : ISegmentWorkflow
    {
        private IRepository _repository;

        public SegmentWorkflow(IRepository repository)
        {
            _repository = repository;
        }

        private void AddSegmentToCache(ISegment segment)
        {
            _repository.Create(segment);
        }

        public IOperationResponse<ISegment> GetById(int segmentId)
        {
            var cachedSegment = GetCachedSegment(segmentId);
            if (cachedSegment != null) { return new OperationResponse<ISegment> { Data = cachedSegment, Status = OperationStatus.Ok }; }

            var segment = GetSegmentFromStrava(segmentId);
            AddSegmentToCache(segment);
            
            return new OperationResponse<ISegment>() { Data = segment, Status = OperationStatus.Ok };
        }

        private ISegment GetCachedSegment(int segmentId)
        {
            return _repository.Read(segmentId);
        }

        private ISegment GetSegmentFromStrava(int segmentId)
        {
            // TODO: Refactor the Endpoints type; Refactor the uri being built and refactor the WebRequest type.
            var json = WebRequest.SendGet(new Uri(string.Format("{0}/{1}?access_token={2}", Endpoints.Leaderboard, segmentId,
                        Thread.CurrentPrincipal.Identity.Name)));
            return Unmarshaller.Unmarshal<ISegment>(json);
        }
    }
}
