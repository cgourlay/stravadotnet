using System.Globalization;

using Nancy;

using com.strava.api.Model.Segments;
using com.strava.api.Representations;
using com.strava.api.Workflows;

namespace com.strava.api.Modules
{
    public class SegmentModule : NancyModule
    {
        private const string BaseEndpoint = @"/Segments";
        private readonly ISegmentWorkflow _segmentWorkflow;

        public SegmentModule(ISegmentWorkflow segmentWorkflow) : base(BaseEndpoint)
        {
            _segmentWorkflow = segmentWorkflow;

            Get["/{id:int}"] = GetSegment;
        }

        private dynamic GetSegment(dynamic parameters)
        {
            OperationResponse<ISegment> operationResponse = _segmentWorkflow.GetById(parameters.Id);
            if (!operationResponse.OperationSucceeded) { return (HttpStatusCode) operationResponse.Status; }
            return Negotiate.WithHeader("ETag", string.Format("\"{0}\"", operationResponse.Data.GetHashCode().ToString(CultureInfo.InvariantCulture)))
                            .WithHeader("Location", string.Format(@"{0}/{1}", BaseEndpoint, operationResponse.Data.Id))
                            .WithStatusCode((HttpStatusCode)operationResponse.Status)
                            .WithModel(operationResponse.DataAsJson());
        }
    }
}