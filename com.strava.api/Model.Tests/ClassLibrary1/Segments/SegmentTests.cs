using com.strava.api.Activities;
using com.strava.api.Model.Segments;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests.Segments
{
    [TestFixture]
    public class SegmentTests
    {
        public class Created : SegmentTests
        {
            [Test]
            public void CanGetDateTimeCreated()
            {
                var segment = new Segment();
                Assert.That(segment.Created, Is.EqualTo(DateTime.MinValue));
            }

            [Test]
            public void CanSetDateTimeCreated()
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
            public void CanGetIsHazardous()
            {
                var segment = new Segment();
                Assert.That(segment.IsHazardous, Is.False);
            }

            [Test]
            public void CanSetIsHazardous()
            {
                var segment = new Segment();

                segment.IsHazardous = true;
                Assert.That(segment.IsHazardous, Is.True);
            }
        }

        public class Map : SegmentTests
        {
            [Test]
            public void CanGetMap()
            {
                var segment = new Segment();
                Assert.That(segment.Map, Is.Null);
            }

            [Test]
            public void CanSetMap()
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
            public void CanGetNumberOfAthletes()
            {
                var segment = new Segment();
                Assert.That(segment.NumberOfAthletes, Is.EqualTo(0));
            }

            [Test]
            public void CanSetNumberOfAthletes()
            {
                var segment = new Segment();

                segment.NumberOfAthletes = 100;
                Assert.That(segment.NumberOfAthletes, Is.EqualTo(100));
            }
        }

        public class NumberOfEfforts : SegmentTests
        {
            [Test]
            public void CanGetNumberOfEfforts()
            {
                var segment = new Segment();
                Assert.That(segment.NumberOfEfforts, Is.EqualTo(0));
            }

            [Test]
            public void CanSetNumberOfEfforts()
            {
                var segment = new Segment();

                segment.NumberOfEfforts = 100;
                Assert.That(segment.NumberOfEfforts, Is.EqualTo(100));
            }
        }

        public class NumberOfStars : SegmentTests
        {
            [Test]
            public void CanGetNumberOfStars()
            {
                var segment = new Segment();
                Assert.That(segment.NumberOfStars, Is.EqualTo(0));
            }

            [Test]
            public void CanSetNumberOfStars()
            {
                var segment = new Segment();

                segment.NumberOfStars = 100;
                Assert.That(segment.NumberOfStars, Is.EqualTo(100));
            }
        }

        public class TotalElevationGain : SegmentTests
        {
            [Test]
            public void CanGetTotalElevationGain()
            {
                var segment = new Segment();
                Assert.That(segment.TotalElevationGain, Is.EqualTo(0f));
            }

            [Test]
            public void CanSetTotalElevationGain()
            {
                var segment = new Segment();

                segment.TotalElevationGain = 94.58f;
                Assert.That(segment.TotalElevationGain, Is.EqualTo(94.58f));
            }
        }

        public class Updated : SegmentTests
        {
            [Test]
            public void CanGetDateTimeUpdated()
            {
                var segment = new Segment();
                Assert.That(segment.Updated, Is.EqualTo(DateTime.MinValue));
            }

            [Test]
            public void CanSetDateTimeUpdated()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment();

                segment.Updated = someDateTime;
                Assert.That(segment.Updated, Is.EqualTo(someDateTime));
            }
        }
    }
}
