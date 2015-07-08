using System;

using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

using com.Strava.api.Activities;
using com.Strava.api.Model.Segments;

namespace Model.Tests.Segments
{
    [TestFixture]
    public class SegmentTests
    {
        public class Created : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"created_at\":\"2008-01-01T17:44:00\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Created, Is.EqualTo(new DateTime(2008, 1, 1, 17, 44, 0)));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Created, Is.EqualTo(DateTime.MinValue));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { Created = new DateTime(2008, 1, 1, 17, 44, 0) };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"created_at\":\"2008-01-01T17:44:00\""));
            }

            [Test]
            public void CanSet()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment {Created = someDateTime};
                Assert.That(segment.Created, Is.EqualTo(someDateTime));
            }
        }

        public class IsHazardous : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"hazardous\": false }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.IsHazardous, Is.False);
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.IsHazardous, Is.False);
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { IsHazardous = true };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"hazardous\":true"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {IsHazardous = true};
                Assert.That(segment.IsHazardous, Is.True);
            }
        }

        public class Map : SegmentTests
        {
            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Map, Is.Null);
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();
                var mock = new Mock<IMap>().Object;

                segment.Map = mock; 
                Assert.That(segment.Map, Is.EqualTo(mock));
            }
        }

        public class NumberOfAthletes : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"athlete_count\": 7036 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.NumberOfAthletes, Is.EqualTo(7036));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.NumberOfAthletes, Is.EqualTo(0));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { NumberOfAthletes = 7036 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"athlete_count\":7036"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {NumberOfAthletes = 7036};
                Assert.That(segment.NumberOfAthletes, Is.EqualTo(7036));
            }
        }

        public class NumberOfEfforts : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"effort_count\": 51335 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.NumberOfEfforts, Is.EqualTo(51335));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.NumberOfEfforts, Is.EqualTo(0));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { NumberOfEfforts = 51335 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"effort_count\":51335"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {NumberOfEfforts = 51335};
                Assert.That(segment.NumberOfEfforts, Is.EqualTo(51335));
            }
        }

        public class NumberOfStars : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"star_count\": 3 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.NumberOfStars, Is.EqualTo(3));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.NumberOfStars, Is.EqualTo(0));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { NumberOfStars = 51 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"star_count\":51"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {NumberOfStars = 5};
                Assert.That(segment.NumberOfStars, Is.EqualTo(5));
            }
        }

        public class TotalElevationGain : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"total_elevation_gain\": 3.465 }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.TotalElevationGain, Is.EqualTo(3.465f));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.TotalElevationGain, Is.EqualTo(0f));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { TotalElevationGain = 155.7f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"total_elevation_gain\":155.7"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment {TotalElevationGain = 94.58f};
                Assert.That(segment.TotalElevationGain, Is.EqualTo(94.58f));
            }
        }

        public class Updated : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                const string json = "{ \"updated_at\":\"2013-09-04T20:00:50\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Updated, Is.EqualTo(new DateTime(2013, 9, 4, 20, 0, 50)));
            }

            [Test]
            public void CanGet()
            {
                var segment = new Segment();
                Assert.That(segment.Updated, Is.EqualTo(DateTime.MinValue));
            }

            [Test]
            public void CanSerialiseToJson()
            {
                var segment = new Segment { Updated = new DateTime(2013, 9, 4, 20, 0, 50) };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Is.StringContaining("\"updated_at\":\"2013-09-04T20:00:50\""));
            }

            [Test]
            public void CanSet()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment {Updated = someDateTime};
                Assert.That(segment.Updated, Is.EqualTo(someDateTime));
            }
        }
    }
}
