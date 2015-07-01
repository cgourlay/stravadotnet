using System.Linq;

using Newtonsoft.Json;

namespace com.strava.api.Representations
{
    public class OperationResponse : BaseRepresentation
    {
        public virtual bool OperationSucceeded { get { return new[] {OperationStatus.Ok, OperationStatus.Created, OperationStatus.Accepted, OperationStatus.NoContent}.Contains(Status); } set { } }
        public virtual OperationStatus Status { get; set; }
    }

    public class OperationResponse<T> : OperationResponse where T : class
    {
        public virtual T Data { set; get; }

        public virtual string DataAsJson()
        {
            return JsonConvert.SerializeObject(Data);
        }
    }
}