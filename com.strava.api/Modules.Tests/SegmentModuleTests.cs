using System.Collections.Generic;

using Moq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

using com.strava.api.Representations;
using com.strava.api.Model.Segments;
using com.strava.api.Modules;
using com.strava.api.Workflows;

namespace Modules.Tests
{
    [TestFixture]
    public class SegmentModuleTests
    {
        public class GetSegment : SegmentModuleTests
        {
            [Test]
            public void OnlyReturnsNotFoundStatusCodeWhenInvalidIdProvided()
            {
                var handlerMock = new Mock<ISegmentWorkflow>();
                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentWorkflow>(handlerMock.Object);
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

            [Test]
            public void OnlyReturnsStatusCodeWhenOperationFails()
            {
                var handlerMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.Status, OperationStatus.InternalServerError);
                responseMock.SetupProperty(s => s.OperationSucceeded, false);
                handlerMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentWorkflow>(handlerMock.Object);
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
            [Ignore("TODO: CG to complete... Refer to issue #31 for further information.")]
            public void ReturnsEtagHeaderWhenSegmentFound()
            {
            }

            [Test]
            public void ReturnsLocationHeaderWhenSegmentFound()
            {
                var handlerMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                handlerMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentWorkflow>(handlerMock.Object);
                });

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Headers["Location"], Is.EqualTo(string.Format(@"/Segments/{0}",229781)));
            }

            [Test]
            public void ReturnsModelWhenSegmentFound()
            {
                var handlerMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                responseMock.SetupProperty(s => s.Data.Name, "Hawk Hill");
                responseMock.Setup(s => s.DataAsJson()).Returns("{ \"name\": \"Hawk Hill\" }");
                handlerMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);
                
                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentWorkflow>(handlerMock.Object);
                });

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.Body.AsString(), Is.StringContaining("Hawk Hill"));
            }

            [Test]
            public void ReturnsStatusCodeWhenSegmentFound()
            {
                var handlerMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                handlerMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentWorkflow>(handlerMock.Object);
                });

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }
    }
}
