using System;
using System.Globalization;
using com.strava.api.Activities;
using com.strava.api.Filters;

namespace com.strava.api.Common
{

    /// <summary>
    ///  Helper class to create correct url parameters for the strava api
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        ///  TimeFilter to string
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static string TimeFilterToString(TimeFilter filter)
        {
            String fltr = String.Empty;
            switch (filter)
            {
                case TimeFilter.ThisMonth:
                    fltr = "this_month";
                    break;
                case TimeFilter.ThisWeek:
                    fltr = "this_week";
                    break;
                case TimeFilter.ThisYear:
                    fltr = "this_year";
                    break;
                case TimeFilter.Today:
                    fltr = "today";
                    break;
            }
            return fltr;
        }

        /// <summary>
        ///  AgeGroup to string
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static string AgeGroupToString(AgeFilter age)
        {
            String ageFilter = String.Empty;

            switch (age)
            {
                case AgeFilter.One:
                    ageFilter = "0_24";
                    break;
                case AgeFilter.Two:
                    ageFilter = "25_34";
                    break;
                case AgeFilter.Three:
                    ageFilter = "35_44";
                    break;
                case AgeFilter.Four:
                    ageFilter = "45_54";
                    break;
                case AgeFilter.Five:
                    ageFilter = "55_64";
                    break;
                case AgeFilter.Six:
                    ageFilter = "65_plus";
                    break;
            }
            return ageFilter;
        }

        
        /// <summary>
        ///  WeightClass to string
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static string WeightClassToString(WeightFilter weight)
        {
            String weightClass = String.Empty;

            switch (weight)
            {
                case WeightFilter.One:
                    weightClass = "0_54";
                    break;
                case WeightFilter.Two:
                    weightClass = "55_64";
                    break;
                case WeightFilter.Three:
                    weightClass = "65_74";
                    break;
                case WeightFilter.Four:
                    weightClass = "75_84";
                    break;
                case WeightFilter.Five:
                    weightClass = "85_94";
                    break;
                case WeightFilter.Six:
                    weightClass = "95_plus";
                    break;
            }
            return weightClass;
        }

        /// <summary>
        ///  Boundaries to string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string BoundariesToString(Coordinate a, Coordinate b)
        {
            String bnds = String.Format("{0},{1},{2},{3}",
            a.Latitude.ToString(CultureInfo.InvariantCulture),
            a.Longitude.ToString(CultureInfo.InvariantCulture),
            b.Latitude.ToString(CultureInfo.InvariantCulture),
            b.Longitude.ToString(CultureInfo.InvariantCulture)
            );

            return bnds;
        }
    }
}
