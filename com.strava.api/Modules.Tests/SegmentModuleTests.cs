﻿using System.Collections.Generic;

using Moq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

using com.strava.api.Dtos;
using com.strava.api.Handlers;
using com.strava.api.Model.Segments;
using com.strava.api.Modules;

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
                var handlerMock = new Mock<ISegmentHandler>();
                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentHandler>(handlerMock.Object);
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
                var handlerMock = new Mock<ISegmentHandler>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.Status, OperationStatus.InternalServerError);
                responseMock.SetupProperty(s => s.OperationSucceeded, false);
                handlerMock.Setup(m => m.GetById(It.IsAny<int>())).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentHandler>(handlerMock.Object);
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
            [Ignore("Refer to issue #31")]
            public void ReturnsEtagHeaderWhenSegmentFound()
            {
            }

            [Test]
            public void ReturnsLocationHeaderWhenSegmentFound()
            {
                var handlerMock = new Mock<ISegmentHandler>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                handlerMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentHandler>(handlerMock.Object);
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
                //var handlerMock = new Mock<ISegmentHandler>();
                //var responseMock = new Mock<OperationResponse<ISegment>>();

                //responseMock.SetupProperty(s => s.OperationSucceeded, true);
                //responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);

                //ISegment data = Mock.Of<ISegment>(ctx => ctx.Id = &&
                //                                         ctx.ActivityType = &&
                //                                         ctx.AverageGrade = &&
                //                                         ctx.ClimbType = &&
                //                                         ctx.City = &&
                //                                         ctx.Country = &&
                //                                         ctx.Distance = &&
                //                                         ctx.EndCoordinates = &&
                //                                         ctx.IsPrivate = &&
                //                                         ctx.MaximumElevation = &&
                //                                         ctx.MaximumGrade = &&
                //                                         ctx.MinimumElevation = &&
                //                                         ctx.Name = &&
                //                                         ctx.ResourceState = &&
                //                                         ctx.IsStarred = &&
                //                                         ctx.StartCoordinates = &&
                //                                         ctx.State = &&
                //                                         ctx.Created = &&
                //                                         ctx.IsHazardous = &&
                //                                         ctx.Map = &&
                //                                         ctx.NumberOfAthletes = &&
                //                                         ctx.NumberOfEfforts = &&
                //                                         ctx.NumberOfStars = &&
                //                                         ctx.TotalElevationGain = &&
                //                                         ctx.Updated = &&);

                //responseMock.SetupProperty(s => s.Data, data);
                //handlerMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                //var browser = new Browser(with =>
                //{
                //    with.Module<SegmentModule>();
                //    with.Dependency<ISegmentHandler>(handlerMock.Object);
                //});

                //var response = browser.Get("/Segments/229781", with =>
                //{
                //    with.HttpRequest();
                //    with.Header("Accept", "application/json");
                //});

                //Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                
            }

            [Test]
            public void ReturnsStatusCodeWhenSegmentFound()
            {
                var handlerMock = new Mock<ISegmentHandler>();
                var responseMock = new Mock<OperationResponse<ISegment>>();

                responseMock.SetupProperty(s => s.OperationSucceeded, true);
                responseMock.SetupProperty(s => s.Status, OperationStatus.Ok);
                responseMock.SetupProperty(s => s.Data.Id, 229781);
                handlerMock.Setup(m => m.GetById(229781)).Returns(responseMock.Object);

                var browser = new Browser(with =>
                {
                    with.Module<SegmentModule>();
                    with.Dependency<ISegmentHandler>(handlerMock.Object);
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
