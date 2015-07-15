using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

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
        private IEndpoints _endpoints;
        private IRepository _repository;

        public SegmentWorkflow(IRepository repository, IEndpoints endpoints)
        {
            _repository = repository;
            _endpoints = endpoints;
        }

        private void AddSegmentToCache(Task<ISegment> segment)
        {
            // TODO: CG to complete...
            //_repository.Create(segment);
        }

        public IOperationResponse<ISegment> GetById(int segmentId)
        {
            var cachedSegment = GetCachedSegment(segmentId);
            if (cachedSegment != null) { return new OperationResponse<ISegment> { Data = cachedSegment, Status = OperationStatus.Ok }; }

            var segment = GetSegmentFromStrava(segmentId);
            
            //AddSegmentToCache(segment);
            return new OperationResponse<ISegment>() { Data = segment.Result, Status = OperationStatus.Ok };
        }

        private ISegment GetCachedSegment(int segmentId)
        {
            //return _repository.Read(segmentId);
            // TODO: CG to complete...
            return null;
        }

        private async Task<Segment> GetSegmentFromStrava(int segmentId)
        {
            var uri = new Uri(string.Format("{0}/{1}?access_token={2}",
                                            _endpoints.Leaderboard, 
                                            segmentId,
                                            Thread.CurrentPrincipal.Identity.Name));
            
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri); 
            if (!response.IsSuccessStatusCode) { return null; }
            return JsonConvert.DeserializeObject<Segment>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
