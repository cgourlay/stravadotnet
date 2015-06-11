using System;
using com.strava.api.Activities;
using com.strava.api.Model.Segments;
using Newtonsoft.Json;

namespace com.strava.api.Segments
{
    /// <summary>
    /// Represents a Strava segment.
    /// </summary>
    public class Segment : BaseSegment
    {
        // TODO: CG to complete... This json does not appear to be defined within the Strava API v3 (where do they come from?)
        //[JsonProperty("pr_time")]
        //public int PersonalRecordTime { get; set; }

        //[JsonProperty("pr_distance")]
        //public float PersonalRecordDistance { get; set; }
    }
}
