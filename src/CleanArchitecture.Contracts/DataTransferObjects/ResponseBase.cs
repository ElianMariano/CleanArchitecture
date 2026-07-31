namespace CleanArchitecture.Contracts.DataTransferObjects;

public abstract class ResponseBase<T>(
    T data,
    int statusCode = 200,
    bool success = true)
{
    public T Data { get; set; } = data;

    public int StatusCode { get; set; } = statusCode;

    public bool Success { get; set; } = success;
}