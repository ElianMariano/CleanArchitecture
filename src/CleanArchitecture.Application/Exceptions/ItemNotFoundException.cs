namespace CleanArchitecture.Application.Exceptions;

public sealed class ItemNotFoundException : ApplicationException
{
    public ItemNotFoundException(Guid ItemId) : base(ApplicationExceptionMessages.ITEM_NOT_FOUND, ItemId)
    {
    }
}