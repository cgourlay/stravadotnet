using System;

using SwimBikeRun.Strive.Model.Enums.Classifications;

namespace SwimBikeRun.Strive.Model.Segments
{
    public interface ILeaderboardEntry
    {
        long ActivityId { get; set; }
        Gender AthleteGender { get; set; }
        long AthleteId { get; set; }
        string AthleteName { get; set; }
        Uri AthleteProfile { get; set; }
        float? AverageHeartRate { get; set; }
        float? AveragePower { get; set; }
        float Distance { get; set; }
        long EffortId { get; set; }
        int ElapsedTime { get; set; }
        int MovingTime { get; set; }
        int Rank { get; set; }
        DateTime StartDate { get; set; }
        DateTime StartDateLocal { get; set; }
    }
}