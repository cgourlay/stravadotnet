using Newtonsoft.Json;

namespace com.Strava.Api.Statistics
{
    public class RecentRunTotals
    {
        /// <summary>
        /// The number of activities.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// The total distance (in meters).
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// The total moving time (in seconds).
        /// </summary>
        [JsonProperty("moving_time")]
        public int MovingTime { get; set; }

        /// <summary>
        /// The total elapsed time (in seconds).
        /// </summary>
        [JsonProperty("elapsed_time")]
        public int ElapsedTime { get; set; }

        /// <summary>
        /// The total elevation gain (in meters).
        /// </summary>
        [JsonProperty("elevation_gain")]
        public double ElevationGain { get; set; }

        /// <summary>
        /// The number of achievements earned.
        /// </summary>
        [JsonProperty("achievement_count")]
        public int AchievementCount { get; set; }
    }
}