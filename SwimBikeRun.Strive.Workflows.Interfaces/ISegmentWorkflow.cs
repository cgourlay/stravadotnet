using System.Collections.Generic;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;

namespace SwimBikeRun.Strive.Workflows.Interfaces
{
    public interface ISegmentWorkflow
    {
        IOperationResponse<ISegment> GetById(int segmentId);
        IOperationResponse<ILeaderboard> GetSegmentLeaderboard(int segmentId, IDictionary<string, string> queryParameters);   
    }
}