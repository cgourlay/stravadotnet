using SwimBikeRun.Strive.Representations.Enums;

namespace SwimBikeRun.Strive.Representations.Interfaces
{
    public interface IOperationResponse
    {
        bool OperationSucceeded { get; set; }
        OperationStatus Status { get; set; }
    }

    public interface IOperationResponse<T> : IOperationResponse
    {
        T Data { set; get; }
        string DataAsJson();
    }
}