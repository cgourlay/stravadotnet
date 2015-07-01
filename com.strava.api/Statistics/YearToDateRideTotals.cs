using Newtonsoft.Json;

namespace com.strava.api.Statistics
{
    /// <summary>
    /// Represents this years ride totals for a Strava athelete.
    /// </summary>
    public class YearToDateRideTotals
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
        public int Distance { get; set; }

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
        public int ElevationGain { get; set; }
    }
}