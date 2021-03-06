﻿using NUnit.Framework;

namespace SwimBikeRun.Strive.Representations.Tests
{
    [TestFixture]
    public class BaseRepresentationTests
    {
        public class ApplicationNamespace : BaseRepresentationTests
        {
            [Test]
            public void CanGet()
            {
                Assert.That(BaseRepresentation.ApplicationNamespace.ToString(), Is.EqualTo(@"http://schemas.swim-bike-run/strive"));
            }
        }

        public class DomainApplicationProtocolNamespace : BaseRepresentationTests
        {
            [Test]
            public void CanGet()
            {
                Assert.That(BaseRepresentation.DomainApplicationProtocolNamespace, Is.EqualTo(@"http://schemas.swim-bike-run/strive/dap"));
            }
        }

        public class ApplicationMediaType : BaseRepresentationTests
        {
            [Test]
            public void CanGet()
            {
                Assert.That(BaseRepresentation.ApplicationMediaType, Is.EqualTo(@"application/vnd.strive+json"));
            }
        }

        public class SelfRelationValue : BaseRepresentationTests
        {
            [Test]
            public void CanGet()
            {
                Assert.That(BaseRepresentation.SelfRelationValue, Is.EqualTo(@"self"));
            }
        }
    }
}
