using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

using com.strava.api.Activities;
using com.strava.api.Model.Segments;

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
                string json = "{ \"created_at\":\"2015-06-21T19:08:00\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Created, Is.EqualTo(new DateTime(2015, 6, 21, 19, 8, 0)));
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
                var segment = new Segment() { Created = new DateTime(2015, 6, 21, 19, 8, 0) };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"created_at\":\"2015-06-21T19:08:00\""));
            }

            [Test]
            public void CanSet()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment();

                segment.Created = someDateTime;
                Assert.That(segment.Created, Is.EqualTo(someDateTime));
            }
        }

        public class IsHazardous : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                string json = "{ \"hazardous\": false }";
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
                var segment = new Segment() { IsHazardous = false };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"hazardous\":false"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();

                segment.IsHazardous = true;
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
                string json = "{ \"athlete_count\": 7036 }";
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
                var segment = new Segment() { NumberOfAthletes = 7036 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"athlete_count\":7036"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();

                segment.NumberOfAthletes = 100;
                Assert.That(segment.NumberOfAthletes, Is.EqualTo(100));
            }
        }

        public class NumberOfEfforts : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                string json = "{ \"effort_count\": 51335 }";
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
                var segment = new Segment() { NumberOfEfforts = 51335 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"effort_count\":51335"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();

                segment.NumberOfEfforts = 51335;
                Assert.That(segment.NumberOfEfforts, Is.EqualTo(51335));
            }
        }

        public class NumberOfStars : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                string json = "{ \"star_count\": 3 }";
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
                var segment = new Segment() { NumberOfStars = 51 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"star_count\":51"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();

                segment.NumberOfStars = 5;
                Assert.That(segment.NumberOfStars, Is.EqualTo(5));
            }
        }

        public class TotalElevationGain : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                string json = "{ \"total_elevation_gain\": 3.465 }";
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
                var segment = new Segment() { TotalElevationGain = 155.7f };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"total_elevation_gain\":155.7"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();

                segment.TotalElevationGain = 94.58f;
                Assert.That(segment.TotalElevationGain, Is.EqualTo(94.58f));
            }
        }

        public class Updated : SegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                string json = "{ \"updated_at\":\"2015-06-21T19:08:00\" }";
                var segment = JsonConvert.DeserializeObject<Segment>(json);
                Assert.That(segment.Updated, Is.EqualTo(new DateTime(2015, 6, 21, 19, 8, 0)));
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
                var segment = new Segment() { Updated = new DateTime(2015, 6, 21, 19, 8, 0) };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"updated_at\":\"2015-06-21T19:08:00\""));
            }

            [Test]
            public void CanSet()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment();

                segment.Updated = someDateTime;
                Assert.That(segment.Updated, Is.EqualTo(someDateTime));
            }
        }
    }
}
