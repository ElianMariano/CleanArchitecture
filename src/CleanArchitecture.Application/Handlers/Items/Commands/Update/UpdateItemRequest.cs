using CleanArchitecture.Domain.Enumerations;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Update;

public sealed class UpdateItemRequest
{
    public Guid ItemId { get; init; }

    public string Name { get; init; } = default!;

    public string? Description { get; init; }

    public double? Value { get; init; }

    public ItemStatus Status { get; init; }
}