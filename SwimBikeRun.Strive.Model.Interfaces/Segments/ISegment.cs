using System;
using SwimBikeRun.Model.Segments;
using SwimBikeRun.Strive.Model.Interfaces.Activities;

namespace SwimBikeRun.Strive.Model.Interfaces.Segments
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