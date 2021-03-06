﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwimBikeRun.Strive.Model.Converters;
using SwimBikeRun.Strive.Model.Interfaces.Activities;
using SwimBikeRun.Strive.Model.Interfaces.Segments;

namespace SwimBikeRun.Strive.Model.Segments
{
    public sealed class Segment : SegmentBase, ISegment
    {
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("hazardous")]
        public bool IsHazardous { get; set; }

        [JsonProperty("map")]
        [JsonConverter(typeof(MapConverter))]
        public IMap Map { get; set; }

        [JsonProperty("athlete_count")]
        public int NumberOfAthletes { get; set; }

        [JsonProperty("effort_count")]
        public int NumberOfEfforts { get; set; }

        [JsonProperty("star_count")]
        public int NumberOfStars { get; set; }

        [JsonProperty("total_elevation_gain")]
        public float TotalElevationGain { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Updated { get; set; }
    }
}
