using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SwimBikeRun.Strive.Model.Interfaces.Segments;

using SwimBikeRun.Strive.Model.Segments; // TODO: CG to complete... JsonConvert. is forcing me to use a concrete type!
using SwimBikeRun.Strive.Repositories;
using SwimBikeRun.Strive.Representations;
using SwimBikeRun.Strive.Representations.Enums;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Workflows
{
    public class LeaderboardWorkflow : ILeaderboardWorkflow
    {
        private IEndpoints _endpoints;
        private IRepository _repository;

        public LeaderboardWorkflow(IRepository repository, IEndpoints endpoints)
        {
            _repository = repository;
            _endpoints = endpoints;
        }

        public IOperationResponse<ILeaderboard> GetById(int segmentId)
        {
            var leaderboard = GetLeaderBoardFromStrava(segmentId);
            
            return new OperationResponse<ILeaderboard>() { Data = leaderboard.Result, Status = OperationStatus.Ok };
        }


        private async Task<Leaderboard> GetLeaderBoardFromStrava(int segmentId)
        {
            var uri = new Uri(string.Format("{0}/{1}/leaderboard?access_token={2}",
                                            _endpoints.Leaderboard, 
                                            segmentId,
                                            Thread.CurrentPrincipal.Identity.Name));
            
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri); 
            if (!response.IsSuccessStatusCode) { return null; }
            return JsonConvert.DeserializeObject<Leaderboard>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
