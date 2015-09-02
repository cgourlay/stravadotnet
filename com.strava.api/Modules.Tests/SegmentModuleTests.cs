using System.Threading;

using Moq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

using SwimBikeRun.Strive.Model.Interfaces.Segments;
using SwimBikeRun.Strive.Modules.Security;
using SwimBikeRun.Strive.Representations.Enums;
using SwimBikeRun.Strive.Representations.Interfaces;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Modules.Tests
{
    [TestFixture]
    public class SegmentModuleTests
    {
        public class RouteConstraints : SegmentModuleTests
        {
            [Test]
            public void Returns404WhenSegmentIdIsNonNumeric()
            {
                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(new Mock<ISegmentWorkflow>().Object);
                });

                var response = browser.Get("/Segments/foo", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });


                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(response.Headers.Count, Is.EqualTo(0));
                Assert.That(response.Body, Is.Empty);
            }
        }

        public class GetSegment : SegmentModuleTests
        {
            [Test]
            public static void OperationFailedDueToAnInternalServerError()
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

                var response = browser.Get("/Segments/1234567890", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(response.Headers.Count, Is.EqualTo(0));
                Assert.That(response.Body, Is.Empty);
            }

            [Test]
            public static void OperationSucceeded()
            {
                var workflowMock = new Mock<ISegmentWorkflow>();
                var responseMock = new Mock<IOperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Data.Id, 1234567890);
                responseMock.SetupProperty(s => s.Data.Name, "Foo Bar");
                responseMock.Setup(s => s.DataAsJson()).Returns("{ \"name\": \"Foo Bar\" }");
                workflowMock.Setup(m => m.GetById(1234567890)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency(workflowMock.Object);
                });

                var response = browser.Get("/Segments/1234567890", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Headers["Location"], Is.EqualTo("/Segments/1234567890"));
                Assert.That(response.Body.AsString(), Is.StringContaining("Foo Bar"));
            }
        }

        public class ContentNegotiation : SegmentModuleTests
        {
            [Test]
            [Ignore("TODO: CG to complete... Refer to issue #31 for further information.")]
            public static void ReturnsEtag()
            {
            }

            [Test]
            public static void ReturnsLocation()
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
            public static void ReturnsStatusCode()
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
            public static void ReturnsModelAsJson()
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

        public class Authorization : SegmentModuleTests
        {
            [Test]
            public static void HandlesMissingAuthorizationHeader()
            {
                var browser = new Browser(new Bootstrapper());

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            }

            [Test]
            public static void HandlesNullAuthorizationToken()
            {
                var browser = new Browser(new Bootstrapper());

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                    with.Header("Authorization", null);
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            }

            [Test]
            public static void HandlesMissingAuthorizationToken()
            {
                var browser = new Browser(new Bootstrapper());

                var response = browser.Get("/Segments/229781", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                    with.Header("Authorization", string.Empty);
                });

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            }

            [Test]
            public static void UserTokenAttachedToThread()
            {
                var browser = new Browser(new Bootstrapper());
                var expectedUser = new User { UserName = "1234567890" };

                browser.Get("/Segments/1234", with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                    with.Header("Authorization", "1234567890");
                });

                Assert.That(Thread.CurrentPrincipal.Identity.Name, Is.EqualTo(expectedUser.UserName));
            }
        }
    }
}
