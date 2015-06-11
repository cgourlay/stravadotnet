﻿using System.Device.Location;

using Newtonsoft.Json;

using com.strava.api.Model.Activities;
using com.strava.api.Model.Converters;
using Newtonsoft.Json.Converters;

namespace com.strava.api.Model.Segments
{
    public class BaseSegment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("activity_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityType ActivityType { get; set; }

        [JsonProperty("average_grade")]
        public float AverageGrade { get; set; }

        [JsonProperty("climb_category")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClimbType ClimbType { get; set; } 

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; } // TODO: CG to complete... Do we really want to use a string here?

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("end_latlng")]
        [JsonConverter(typeof(GeoCoordinateConverter))]
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
        [JsonConverter(typeof(GeoCoordinateConverter))]
        public GeoCoordinate StartCoordinates { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
