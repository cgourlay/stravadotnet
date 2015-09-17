using System.Collections.Generic;

using Newtonsoft.Json;

namespace SwimBikeRun.Strive.Model.Segments
{
    public sealed class Leaderboard
    {
        public Leaderboard()
        {
            Entries = new List<LeaderboardEntry>();
        }

        [JsonProperty("entry_count")]
        public int EntryCount { get; set; }

        [JsonProperty("entries")]
        public List<LeaderboardEntry> Entries { get; set; }
    }
}
