using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SwimBikeRun.Strive.Model.Converters;
using SwimBikeRun.Strive.Model.Enums.Classifications;
using SwimBikeRun.Strive.Model.Interfaces.Segments;

namespace SwimBikeRun.Strive.Model.Segments
{
    public sealed class LeaderboardEntry : ILeaderboardEntry
    {
        [JsonProperty("activity_id")]
        public long ActivityId { get; set; }

        [JsonProperty("athlete_gender")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender AthleteGender { get; set; }

        [JsonProperty("athlete_id")]
        public long AthleteId { get; set; }

        [JsonProperty("athlete_name")]
        public string AthleteName { get; set; }

        [JsonProperty("athlete_profile")]
        [JsonConverter(typeof(UriConverter))]
        public Uri AthleteProfile { get; set; }

        [JsonProperty("average_hr")]
        public float? AverageHeartRate { get; set; }

        [JsonProperty("average_watts")]
        public float? AveragePower { get; set; }

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("effort_id")]
        public long EffortId { get; set; }

        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("start_date")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartDate { get; set; }
        
        [JsonProperty("start_date_local")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartDateLocal { get; set; }
    }
}
