using com.strava.api.Model.Segments;
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
    }
}
