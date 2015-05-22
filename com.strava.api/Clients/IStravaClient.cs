namespace com.strava.api.Clients
{
    /// <summary>
    /// The StravaClient is used to receive data from Strava. The client offers various subclients, which you can use to
    /// receive the data. 
    /// <list type="bullet">
    /// <listheader>
    ///    <term>Currently the following Strava API resources are supported:</term>
    /// </listheader>
    /// <item>
    ///     <term>Activities</term>
    /// </item>
    /// <item>
    ///     <term>Athletes</term>
    /// </item>
    /// <item>
    ///     <term>Clubs</term>
    /// </item>
    /// <item>
    ///     <term>Gear</term>
    /// </item>
    /// <item>
    ///     <term>Segments</term>
    /// </item>
    /// <item>
    ///     <term>Segment Efforts</term>
    /// </item>
    /// <item>
    ///     <term>Stats</term>
    /// </item>
    /// <item>
    ///     <term>Streams</term>
    /// </item>
    /// </list>
    /// </summary>
    public interface IStravaClient
    {
        /// <summary>
        /// Predefined ActivityClient.
        /// </summary>
        ActivityClient Activities { get; set; }

        /// <summary>
        /// Predefined AthleteClient.
        /// </summary>
        AthleteClient Athletes { get; set; }

        /// <summary>
        /// Predefined ClubClient.
        /// </summary>
        ClubClient Clubs { get; set; }

        /// <summary>
        /// Predefined GearClient.
        /// </summary>
        GearClient Gear { get; set; }

        /// <summary>
        /// Predefined SegmentClient.
        /// </summary>
        SegmentClient Segments { get; set; }

        /// <summary>
        /// Predefined StreamClient.
        /// </summary>
        StreamClient Streams { get; set; }

        /// <summary>
        /// Predefined StatsClient.
        /// </summary>
        StatsClient Stats { get; set; }

        /// <summary>
        /// The UploadClient is used to upload new activities to Strava.
        /// </summary>
        UploadClient Uploads { get; set; }

        /// <summary>
        /// The EffortClient is used to receive efforts on a segment.
        /// </summary>
        EffortClient Efforts { get; set; }

        /// <summary>
        /// Returns the framework version of the StravaClient.
        /// </summary>
        /// <returns>The version number of the StravaClient.</returns>
        string ToString();
    }
}