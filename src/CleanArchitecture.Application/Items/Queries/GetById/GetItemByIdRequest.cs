namespace CleanArchitecture.Application.Items.Queries.GetById;

public sealed class GetItemByIdRequest(Guid itemId)
{
    public Guid ItemId { get; set; } = itemId;
}