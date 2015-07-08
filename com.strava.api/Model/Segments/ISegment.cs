using System;

using com.Strava.api.Activities;

namespace SwimBikeRun.Model.Segments
{
    public interface ISegment : IBaseSegment
    {
        DateTime Created { get; set; }
        bool IsHazardous { get; set; }
        IMap Map { get; set; }
        int NumberOfAthletes { get; set; }
        int NumberOfEfforts { get; set; }
        int NumberOfStars { get; set; }
        float TotalElevationGain { get; set; }
        DateTime Updated { get; set; }
    }
}