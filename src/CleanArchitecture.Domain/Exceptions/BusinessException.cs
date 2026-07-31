namespace CleanArchitecture.Domain.Exceptions;

public sealed class BusinessException : DomainException
{
    public BusinessException(string errorCode) : base(errorCode)
    {
    }
}