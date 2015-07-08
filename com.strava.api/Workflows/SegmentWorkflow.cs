﻿using System;
using System.Threading;

using com.Strava.api.Api;
using com.Strava.api.Common;
using com.Strava.api.Repositories;
using com.Strava.api.Representations;
using com.Strava.api.Http;
using com.Strava.api.Model.Segments;

using Neo4jClient;

namespace com.Strava.api.Workflows
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
