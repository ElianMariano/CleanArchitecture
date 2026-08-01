namespace CleanArchitecture.Application.Handlers.Items.Commands.Delete;

public sealed class DeleteItemRequest
{
    public Guid ItemId { get; init; }
}