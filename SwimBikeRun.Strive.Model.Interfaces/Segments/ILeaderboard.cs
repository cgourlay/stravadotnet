using System.Collections.Generic;

namespace SwimBikeRun.Strive.Model.Interfaces.Segments
{
    public interface ILeaderboard
    {
        int EntryCount { get; set; }
        IList<ILeaderboardEntry> Entries { get; set; }
    }
}