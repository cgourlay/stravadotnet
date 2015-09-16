using System;
using System.Globalization;
using com.Strava.Api.Activities;
using com.Strava.Api.Filters;
using SwimBikeRun.Strive.Model.Enums.Classifications;

namespace com.Strava.Api.Common
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
        public static string AgeGroupToString(AgeGroup age)
        {
            String ageFilter = String.Empty;

            switch (age)
            {
                case AgeGroup.ZeroToTwentyFour:
                    ageFilter = "0_24";
                    break;
                case AgeGroup.TwentyFiveToThirtyFour:
                    ageFilter = "25_34";
                    break;
                case AgeGroup.ThirtyFiveToFortyFour:
                    ageFilter = "35_44";
                    break;
                case AgeGroup.FortyFiveToFiftyFour:
                    ageFilter = "45_54";
                    break;
                case AgeGroup.FiftyFiveToSixtyFour:
                    ageFilter = "55_64";
                    break;
                case AgeGroup.SixtyFivePlus:
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
        public static string WeightClassToString(WeightGroup weight)
        {
            String weightClass = String.Empty;

            switch (weight)
            {
                case WeightGroup.ZeroToOneHundredAndTwentyFourPounds:
                    weightClass = "0_54";
                    break;
                case WeightGroup.HundredAndTwentyFivePoundsToHundredAndFortyNinePounds:
                    weightClass = "55_64";
                    break;
                case WeightGroup.HundredAndFiftyPoundsToHundredAndSixtyFourPounds:
                    weightClass = "65_74";
                    break;
                case WeightGroup.HundredAndSixtyFivePoundsToHundredAndSeventyNinePounds:
                    weightClass = "75_84";
                    break;
                case WeightGroup.HundredAndEightyPoundsToHundredAndNinetyNinePounds:
                    weightClass = "85_94";
                    break;
                case WeightGroup.TwoHundredPlusPounds:
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
