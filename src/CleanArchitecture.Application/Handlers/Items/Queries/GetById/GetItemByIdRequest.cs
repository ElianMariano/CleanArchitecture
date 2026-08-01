namespace CleanArchitecture.Application.Handlers.Items.Queries.GetById;

public sealed class GetItemByIdRequest(Guid itemId)
{
    public Guid ItemId { get; set; } = itemId;
}