namespace SwimBikeRun.Strive.Model.Interfaces.Activities
{
    public interface IMap
    {
        string Id { get; set; }
        string Polyline { get; set; }
        string SummaryPolyline { get; set; }
        int ResourceState { get; set; }
    }
}
