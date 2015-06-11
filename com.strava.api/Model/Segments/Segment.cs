using com.strava.api.Activities;

using Newtonsoft.Json;

namespace com.strava.api.Model.Segments
{
    internal sealed class Segment : BaseSegment
    {
        [JsonProperty("athlete_count")]
        public int AthleteCount { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("effort_count")]
        public int EffortCount { get; set; }

        [JsonProperty("hazardous")]
        public bool IsHazardous { get; set; }

        [JsonProperty("map")]
        public Map Map { get; set; }

        [JsonProperty("star_count")]
        public int StarCount { get; set; }

        [JsonProperty("total_elevation_gain")]
        public float TotalElevationGain { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
