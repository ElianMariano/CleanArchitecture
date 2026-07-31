namespace CleanArchitecture.Contracts;

public interface IUnitOfWork
{
    public Task CommitAsync(CancellationToken cancellationToken);
}