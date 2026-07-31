namespace CleanArchitecture.Application.Items.Commands.Delete;

public sealed class DeleteItemRequest
{
    public Guid ItemId { get; init; }
}