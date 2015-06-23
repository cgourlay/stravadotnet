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
    public class BaseSegmentTests
    {
        public class Id : BaseSegmentTests
        {
            [Test]
            public void CanDeserialiseFromJson()
            {
                string json = "{ \"id\":229781 }";
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
                var segment = new Segment() { Id = 229781 };
                var output = JsonConvert.SerializeObject(segment);
                Assert.That(output, Text.Contains("\"id\":229781"));
            }

            [Test]
            public void CanSet()
            {
                var segment = new Segment();

                segment.Id = 229781;
                Assert.That(segment.Id, Is.EqualTo(229781));
            }
        }
    }
}
