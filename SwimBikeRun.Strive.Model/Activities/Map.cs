using System;
using Newtonsoft.Json;
using SwimBikeRun.Strive.Model.Interfaces.Activities;

namespace SwimBikeRun.Strive.Model.Activities
{
    public class Map : IMap
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("polyline")]
        public string Polyline { get; set; }

        [JsonProperty("summary_polyline")]
        public string SummaryPolyline { get; set; }

        [JsonProperty("resource_state")]
        public int ResourceState { get; set; }
    }
}
