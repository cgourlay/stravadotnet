using System;
using com.strava.api.Activities;

namespace com.strava.api.Model.Segments
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