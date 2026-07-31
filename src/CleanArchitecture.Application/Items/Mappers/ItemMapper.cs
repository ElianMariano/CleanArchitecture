using CleanArchitecture.Contracts.DataTransferObjects;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Items.Mappers;

public static class ItemMapper
{
    public static Item ToDomain(this ItemBase request)
    {
        return new Item(
            request.Name,
            request.Description,
            request.Value,
            request.Status
        );
    }

    public static ItemBase ToResponse(this Item Item)
    {
        return new ItemBase
        {
            Id = Item.Id.Value,
            Name = Item.Name,
            Description = Item.Description,
            Value = Item.Value,
            Status = Item.Status,
            CreatedAt = Item.CreatedAt
        };
    }
}