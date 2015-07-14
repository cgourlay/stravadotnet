namespace SwimBikeRun.Strive.Representations
{
    public class Endpoints : IEndpoints
    {
        public string Activity { get { return @"https://www.strava.com/api/v3/activities"; } }
        public string Activities { get { return @"https://www.strava.com/api/v3/athlete/activities"; } }
        public string ActivitiesFollowers { get { return @"https://www.strava.com/api/v3/activities/following"; } }
        public string Athlete { get { return @"https://www.strava.com/api/v3/athlete"; } }
        public string Athletes { get { return @"https://www.strava.com/api/v3/athletes"; } }
        public string Club { get { return @"https://www.strava.com/api/v3/clubs"; } }
        public string Clubs { get { return @"https://www.strava.com/api/v3/athlete/clubs"; } }
        public string Friends { get { return @"https://www.strava.com/api/v3/athlete/friends"; } }
        public string Follower { get { return @"https://www.strava.com/api/v3/athlete/followers"; } }
        public string Followers { get { return @"https://www.strava.com/api/v3/athletes"; } }
        public string Gear { get { return @"https://www.strava.com/api/v3/gear"; } }
        public string Leaderboard { get { return @"https://www.strava.com/api/v3/segments"; } }
        public string Starred { get { return @"https://www.strava.com/api/v3/segments/starred"; } }
        public string Uploads { get { return @"https://www.strava.com/api/v3/uploads/"; } }
    }
}
