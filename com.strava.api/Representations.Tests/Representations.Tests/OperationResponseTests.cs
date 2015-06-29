using NUnit.Framework;

using com.strava.api.Representations;

namespace Representations.Tests
{
    [TestFixture]
    public class OperationResponseTests
    {
        public class OperationSucceded : OperationResponseTests
        {
            [Test]
            public void ReturnsTrueWhenOk()
            {
                var operationResponse = new OperationResponse {Status = OperationStatus.Ok};
                Assert.That(operationResponse.OperationSucceeded, Is.True);
            }

            [Test]
            public void ReturnsTrueWhenCreated()
            {
                var operationResponse = new OperationResponse { Status = OperationStatus.Created };
                Assert.That(operationResponse.OperationSucceeded, Is.True);
            }

            [Test]
            public void ReturnsTrueWhenAccepted()
            {
                var operationResponse = new OperationResponse { Status = OperationStatus.Accepted };
                Assert.That(operationResponse.OperationSucceeded, Is.True);
            }

            [Test]
            public void ReturnsTrueWhenNoContent()
            {
                var operationResponse = new OperationResponse { Status = OperationStatus.NoContent };
                Assert.That(operationResponse.OperationSucceeded, Is.True);
            }

            [Test]
            public void ReturnsFalseWhenInternalServerError()
            {
                var operationResponse = new OperationResponse { Status = OperationStatus.InternalServerError };
                Assert.That(operationResponse.OperationSucceeded, Is.False);
            }
        }

        public class Status : OperationResponseTests
        {
            [Test]
            public void CanGet()
            {
                var operationResponse = new OperationResponse();
                Assert.That(operationResponse.Status, Is.EqualTo(OperationStatus.Unknown));
            }

            [Test]
            public void CanSet()
            {
                var operationResponse = new OperationResponse();
                Assert.That(operationResponse.Status, Is.EqualTo(OperationStatus.Unknown));
                operationResponse.Status = OperationStatus.Created;
                Assert.That(operationResponse.Status, Is.EqualTo(OperationStatus.Created));
            }
        }
    }
}
