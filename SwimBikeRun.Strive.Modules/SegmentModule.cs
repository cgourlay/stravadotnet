using System.Collections.Generic;
using System.Globalization;

using Nancy;
using Nancy.Responses.Negotiation;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;


namespace SwimBikeRun.Strive.Modules
{
    public class SegmentModule : SecureModule
    {
        private const string BaseUri = "/segments";
        private readonly ISegmentWorkflow _segmentWorkflow;

        public SegmentModule(ISegmentWorkflow segmentWorkflow) : base(BaseUri)
        {
            _segmentWorkflow = segmentWorkflow;
            Get["/{id:int}"] = GetSegment;
            Get["/{id:int}/leaderboard"] = GetLeaderboard;
        }

        private dynamic GetLeaderboard(dynamic parameters)
        {
            IOperationResponse<ILeaderboard> response = _segmentWorkflow.GetSegmentLeaderboard(parameters.Id, GetQueryStringParameters());
            if (response.OperationSucceeded)
            {
                return Negotiate.WithMediaRangeModel(new MediaRange("application/json"), (Response)response.DataAsJson())
                                .WithStatusCode((HttpStatusCode)response.Status)
                                .WithHeader("ETag", string.Format("\"{0}\"", response.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
            }
            
            return (HttpStatusCode)response.Status;
        }

        private IDictionary<string, string> GetQueryStringParameters()
        {
            return new Dictionary<string, string> 
            {
                { "gender", Request.Query.gender },
                { "age_group", Request.Query.age_group },
                { "weight_class", Request.Query.weight_class },
                { "following", Request.Query.following },
                { "club_id", Request.Query.club_id},
                { "date_range", Request.Query.date_range },
                { "context_entries", Request.Query.context_entries},
                { "page", Request.Query.page},
                { "per_page", Request.Query.per_page}
            };
        }

        private dynamic GetSegment(dynamic parameters)
        {
            IOperationResponse<ISegment> response = _segmentWorkflow.GetById(parameters.Id);
            if (response.OperationSucceeded)
            {
                return Negotiate.WithMediaRangeModel(new MediaRange("application/json"), (Response)response.DataAsJson())
                                .WithStatusCode((HttpStatusCode)response.Status)
                                .WithHeader("Location", string.Format(@"{0}/{1}", BaseUri, response.Data.Id))
                                .WithHeader("ETag", string.Format("\"{0}\"", response.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)));
            }
            
            return (HttpStatusCode)response.Status;
        }
    }
}