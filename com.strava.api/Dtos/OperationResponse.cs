using System.Linq;
using com.strava.api.Common;
using Newtonsoft.Json;

namespace com.strava.api.Dtos
{
    public class OperationResponse : BaseOperationResponse
    {
        public virtual bool OperationSucceeded 
        {
            get { return new[] {OperationStatus.Ok, OperationStatus.Created, OperationStatus.Accepted, OperationStatus.NoContent}.Contains(Status); }
            set { }
        }

        public virtual OperationStatus Status { get; set; }
    }

    public class OperationResponse<T> : OperationResponse where T : class
    {
        public virtual T Data { set; get; }

        
        public virtual string DataAsJson()
        {
            var x =  JsonConvert.SerializeObject(Data,new JsonSerializerSettings {PreserveReferencesHandling = PreserveReferencesHandling.Objects});
            return x;
        }
    }
}
