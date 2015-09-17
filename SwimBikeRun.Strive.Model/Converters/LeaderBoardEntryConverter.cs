using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Model.Segments;

namespace SwimBikeRun.Strive.Model.Converters
{
    public class LeaderBoardEntryConverter : JsonArrayConverter<IList<ILeaderboardEntry>>
    {
        protected override IList<ILeaderboardEntry> Create(Type @type, JArray json)
        {
            if (json == null) { return null; }

            var entries = new List<ILeaderboardEntry>();

            foreach (var entry in json)
            {
                entries.Add(JsonConvert.DeserializeObject<LeaderboardEntry>(entry.ToString()));
            }

            return entries;
        }
    }
}
