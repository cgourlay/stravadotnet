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
            public void CanGetCreationDateTime()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment() { Created = someDateTime };

                Assert.That(segment.Created, Is.EqualTo(someDateTime));
            }

            [Test]
            public void CanSetCreationDate()
            {
                var someDateTime = DateTime.Now;
                var segment = new Segment();

                Assert.That(segment.Created, Is.EqualTo(DateTime.MinValue));
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

                Assert.That(segment.IsHazardous, Is.False);
                segment.IsHazardous = true;
                Assert.That(segment.IsHazardous, Is.True);
            }
        }

        public class Map : SegmentTests
        {
            [Test]
            public void CanGetMap()
            {
                var mock = new Mock<IMap>().Object;
                var segment = new Segment() { Map = mock };
                Assert.That(segment.Map, Is.EqualTo(mock));
            }

            [Test]
            public void CanSetMap()
            {
                var segment = new Segment();
                var mock = new Mock<IMap>().Object;

                Assert.That(segment.Map, Is.Null);
                segment.Map = mock; 
                Assert.That(segment.Map, Is.EqualTo(mock));
            }
        }
    }
}
