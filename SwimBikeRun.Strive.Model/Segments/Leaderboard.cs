using System.Collections.Generic;

using Newtonsoft.Json;
using SwimBikeRun.Strive.Model.Converters;
using SwimBikeRun.Strive.Model.Interfaces.Segments;

namespace SwimBikeRun.Strive.Model.Segments
{
    public sealed class Leaderboard : ILeaderboard
    {
        public Leaderboard()
        {
            Entries = new List<ILeaderboardEntry>();
        }

        public int Id { get; set; }

        [JsonProperty("entry_count")]
        public int EntryCount { get; set; }

        [JsonProperty("entries")]
        [JsonConverter(typeof(LeaderBoardEntryConverter))]
        public IList<ILeaderboardEntry> Entries { get; set; }
    }
}