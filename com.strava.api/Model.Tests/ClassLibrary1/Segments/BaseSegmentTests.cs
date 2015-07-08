using System.Device.Location;

using Newtonsoft.Json;
using NUnit.Framework;

using com.Strava.api.Model.Segments;

namespace Model.Tests.Segments
{
    [TestFixture]
    public class BaseSegmentTests
    {
        public class Id : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"id\":229781 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Id, Is.EqualTo(229781));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Id, Is.EqualTo(0));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { Id = 229781 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"id\":229781"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {Id = 229781};
                Assert.That(segment.Id, Is.EqualTo(229781));
            }
        }

        public class ActivityType : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"activity_type\":\"Ride\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.ActivityType, Is.EqualTo(com.Strava.api.Model.Activities.ActivityType.Ride));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.ActivityType, Is.EqualTo(com.Strava.api.Model.Activities.ActivityType.Unknown));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { ActivityType = com.Strava.api.Model.Activities.ActivityType.Ride };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"activity_type\":\"Ride\""));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {ActivityType = com.Strava.api.Model.Activities.ActivityType.Ride};
                Assert.That(segment.ActivityType, Is.EqualTo(com.Strava.api.Model.Activities.ActivityType.Ride));
            }
        }

        public class AverageGrade : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"average_grade\": 5.7 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.AverageGrade, Is.EqualTo(5.7f));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.AverageGrade, Is.EqualTo(0f));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { AverageGrade = 5.7f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"average_grade\":5.7"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {AverageGrade = 5.7f};

                Assert.That(segment.AverageGrade, Is.EqualTo(5.7f));
            }
        }

        public class City : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"city\":\"San Francisco\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.City, Is.EqualTo("San Francisco"));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.City, Is.Null);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { City = "San Francisco" };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"city\":\"San Francisco\""));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {City = "San Francisco"};
                Assert.That(segment.City, Is.EqualTo("San Francisco"));
            }
        }

        public class ClimbType : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"climb_category\":1 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.ClimbType, Is.EqualTo(com.Strava.api.Model.Segments.ClimbType.CategoryOne));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.ClimbType, Is.EqualTo(com.Strava.api.Model.Segments.ClimbType.CategoryZero));
            }

            [Test]
            [Ignore("The serialization of the StringEnumConverter needs to be modified - refer to issue #30.")]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { ClimbType = com.Strava.api.Model.Segments.ClimbType.CategoryOne };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"climb_category\":1"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {ClimbType = com.Strava.api.Model.Segments.ClimbType.CategoryOne};
                Assert.That(segment.ClimbType, Is.EqualTo(com.Strava.api.Model.Segments.ClimbType.CategoryOne));
            }
        }

        public class Country : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"country\":\"United States\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Country, Is.EqualTo("United States"));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Country, Is.Null);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { Country = "United States" };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"country\":\"United States\""));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {Country = "United States"};
                Assert.That(segment.Country, Is.EqualTo("United States"));
            }
        }

        public class Distance : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"distance\": 2684.82 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Distance, Is.EqualTo(2684.82f));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Distance, Is.EqualTo(0f));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { Distance = 2684.82f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"distance\":2684.82"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {Distance = 2684.82f};

                Assert.That(segment.Distance, Is.EqualTo(2684.82f));
            }
        }

        public class EndCoordinates : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"end_latlng\":[ 37.8280722, -122.4981393 ] }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.EndCoordinates, Is.EqualTo(new GeoCoordinate(37.8280722, -122.4981393)));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.EndCoordinates, Is.Null);
            }

            [Test]
            [Ignore("The serialization of the JsonArrayConverter needs to be implemented - refer to issue #29.")]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { EndCoordinates = new GeoCoordinate(37.8280722, -122.4981393) };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"end_latlng\":[ 37.8280722, -122.4981393 ]"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {EndCoordinates = new GeoCoordinate(37.8280722, -122.4981393)};
                Assert.That(segment.EndCoordinates, Is.EqualTo(new GeoCoordinate(37.8280722, -122.4981393)));
            }
        }

        public class IsPrivate : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"private\": false }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.IsPrivate, Is.False);
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.IsPrivate, Is.False);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { IsPrivate = false };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"private\":false"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {IsPrivate = true};
                Assert.That(segment.IsPrivate, Is.True);
            }
        }

        public class IsStarred : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"starred\": false }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.IsStarred, Is.False);
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.IsStarred, Is.False);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { IsStarred = false };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"starred\":false"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {IsStarred = true};
                Assert.That(segment.IsStarred, Is.True);
            }
        }

        public class MaximumElevation : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"elevation_high\": 245.3 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.MaximumElevation, Is.EqualTo(245.3f));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.MaximumElevation, Is.EqualTo(0f));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { MaximumElevation = 245.3f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"elevation_high\":245.3"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {MaximumElevation = 245.3f};

                Assert.That(segment.MaximumElevation, Is.EqualTo(245.3f));
            }
        }

        public class MaximumGrade : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"maximum_grade\": 14.2 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.MaximumGrade, Is.EqualTo(14.2f));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.MaximumGrade, Is.EqualTo(0f));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { MaximumGrade = 14.2f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"maximum_grade\":14.2"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {MaximumGrade = 14.2f};

                Assert.That(segment.MaximumGrade, Is.EqualTo(14.2f));
            }
        }

        public class MinimumElevation : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"elevation_low\": 92.4 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.MinimumElevation, Is.EqualTo(92.4f));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.MinimumElevation, Is.EqualTo(0f));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { MinimumElevation = 92.4f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"elevation_low\":92.4"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {MinimumElevation = 92.4f};

                Assert.That(segment.MinimumElevation, Is.EqualTo(92.4f));
            }
        }

        public class Name : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"name\":\"Hawk Hill\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Name, Is.EqualTo("Hawk Hill"));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Name, Is.Null);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { Name = "Hawk Hill" };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"name\":\"Hawk Hill\""));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {Name = "Hawk Hill"};
                Assert.That(segment.Name, Is.EqualTo("Hawk Hill"));
            }
        }

        public class ResourceState : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"resource_state\":3 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.ResourceState, Is.EqualTo(3));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.ResourceState, Is.EqualTo(0));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { ResourceState = 3 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"resource_state\":3"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {ResourceState = 3};

                Assert.That(segment.ResourceState, Is.EqualTo(3));
            }
        }

        public class StartCoordinates : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"start_latlng\":[ 37.8331119, -122.4834356 ] }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.StartCoordinates, Is.EqualTo(new GeoCoordinate(37.8331119, -122.4834356)));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.StartCoordinates, Is.Null);
            }

            [Test]
            [Ignore("The serialization of the JsonArrayConverter needs to be implemented - refer to issue #29.")]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { StartCoordinates = new GeoCoordinate(37.8331119, -122.4834356) };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"start_latlng\":[ 37.8331119, -122.4834356 ]"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {StartCoordinates = new GeoCoordinate(37.8331119, -122.4834356)};
                Assert.That(segment.StartCoordinates, Is.EqualTo(new GeoCoordinate(37.8331119, -122.4834356)));
            }
        }

        public class State : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"state\":\"CA\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.State, Is.EqualTo("CA"));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.State, Is.Null);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { State = "CA" };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"state\":\"CA\""));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {State = "CA"};
                Assert.That(segment.State, Is.EqualTo("CA"));
            }
        }
    }
}
