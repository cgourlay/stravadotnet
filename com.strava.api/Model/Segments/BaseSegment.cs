using System.Device.Location;
using Newtonsoft.Json;

namespace com.strava.api.Model.Segments
{
    public class BaseSegment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("activity_type")]
        public string ActivityType { get; set; } // TODO: CG to complete... This can be ‘Ride’ or ‘Run’ - do we really want to use a string?

        [JsonProperty("average_grade")]
        public float AverageGrade { get; set; }

        [JsonProperty("climb_category")]
        public int ClimbCategory { get; set; } // TODO: CG to complete... This is a number in the range 0 to 5 where 0 is lower and 5 is harder - do we really want to use an int?

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; } // TODO: CG to complete... Do we really want to use a string here?

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("end_latlng")]
        public GeoCoordinate EndCoordinates { get; set; }

        [JsonProperty("private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("elevation_high")]
        public float MaximumElevation { get; set; }

        [JsonProperty("maximum_grade")]
        public float MaximumGrade { get; set; }

        [JsonProperty("elevation_low")]
        public float MinimumElevation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }

        [JsonProperty("starred")]
        public bool IsStarred { get; set; }

        [JsonProperty("start_latlng")]
        public GeoCoordinate StartCoordinates { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
