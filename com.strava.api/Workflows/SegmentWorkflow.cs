﻿using System;
using System.Threading;

using com.Strava.Api.Api;
using com.Strava.Api.Common;
using com.Strava.Api.Repositories;
using SwimBikeRun.Representations;
using com.Strava.Api.Http;
using SwimBikeRun.Model.Segments;

using Neo4jClient;
using SwimBikeRun.Strive.Model.Interfaces.Segments;

namespace SwimBikeRun.Workflows
{
    public class SegmentWorkflow : ISegmentWorkflow
    {
        public OperationResponse<ISegment> GetById(int segmentId)
        {
            // Get the segment from the cache.
            var databaseProvider = new Neo4JProvider();
            //databaseProvider.Read(segmentId);

            // If not found in the cache, get the segment from Strava and add to the cache.
            // TODO: Refactor the Endpoints type; Refactor the uri being built and refactor the WebRequest type.
            var json = WebRequest.SendGet(new Uri(string.Format("{0}/{1}?access_token={2}", Endpoints.Leaderboard, segmentId, Thread.CurrentPrincipal.Identity.Name)));
            databaseProvider.Create(Unmarshaller.Unmarshal<Segment>(json));
            // Return the result
            return new OperationResponse<ISegment>() { Data = Unmarshaller.Unmarshal<Segment>(json), Status = OperationStatus.Ok };
        }
    }
}
