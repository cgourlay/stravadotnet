using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Interfaces;

namespace SwimBikeRun.Strive.Workflows.Interfaces
{
    public interface ILeaderboardWorkflow
    {
        IOperationResponse<ILeaderboard> GetById(int segmentId);
    }
}