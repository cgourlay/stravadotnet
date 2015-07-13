using System.Collections.Generic;

using Moq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Representations.Enums;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Modules.Tests
{
    [TestFixture]
    public class SegmentModuleTests
    {
        public class Authorization : SegmentModuleTests
        {
            [Test]
            public void HandlesMissingAuthorizationHeader()
            {
                var browser = new Browser(new Bootstrapper());
                
                var response = browser.Get("/Segments/1234", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(() => response.Headers["ETag"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(() => response.Headers["Location"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(response.Body, Is.Empty);
            }

            [Test]
            public void HandlesNullAuthorizationToken()
            {
                var browser = new Browser(new Bootstrapper());

                var response = browser.Get("/Segments/1234", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                    with.Header("Authorization", null);
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(() => response.Headers["ETag"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(() => response.Headers["Location"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(response.Body, Is.Empty);
            }

            [Test]
            public void HandlesMissingAuthorizationToken()
            {
                var browser = new Browser(new Bootstrapper());

                var response = browser.Get("/Segments/1234", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                    with.Header("Authorization", string.Empty);
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
                Assert.That(() => response.Headers["ETag"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(() => response.Headers["Location"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(response.Body, Is.Empty);
            }
        }

        public class ContentNegotiation : SegmentModuleTests
        {
            [Test]
            [Ignore("TODO: CG to complete... Refer to issue #31 for further information.")]
            public void ReturnsEtag()
            {
            }

            [Test]
            public void ReturnsLocation()
            {
                var workflowMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<IOperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                workflowMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(workflowMock.Object);
                });

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.Headers["Location"], Is.EqualTo(string.Format(@"/Segments/{0}", 229781)));
            }

            [Test]
            public void ReturnsStatusCode()
            {
                var workflowMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<IOperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                workflowMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(workflowMock.Object);
                });

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }

            [Test]
            public void ReturnsModelAsJson()
            {
                var workflowMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<IOperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                responseMock.SetupProperty(s => s.Data.Name, "Hawk Hill");
                responseMock.Setup(s => s.DataAsJson()).Returns("{ \"name\": \"Hawk Hill\" }");
                workflowMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(workflowMock.Object);
                });

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.Body.AsString(), Is.StringContaining("Hawk Hill"));
            }
        }

        public class GetSegment : SegmentModuleTests
        {
            [Test]
            public void HandlesApplicationFailure()
            {
                var workflowMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<IOperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.Status, OperationStatus.InternalServerError);
                responseMock.SetupProperty(s => s.OperationSucceeded, false);
                workflowMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(workflowMock.Object);
                });

                var response = browser.Get("/Segments/1234", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(() => response.Headers["ETag"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(() => response.Headers["Location"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(response.Body, Is.Empty);
            }

            [Test]
            public void HandlesInvalidId()
            {
                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(new Mock<ISegmentWorkflow>().Object);
                });

                var response = browser.Get("/Segments/qwerty", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(() => response.Headers["ETag"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(() => response.Headers["Location"], Throws.Exception.TypeOf<KeyNotFoundException>());
                Assert.That(response.Body, Is.Empty);
            }
        }
    }
}
