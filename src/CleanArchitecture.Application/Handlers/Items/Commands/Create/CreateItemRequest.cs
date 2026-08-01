using CleanArchitecture.Domain.Enumerations;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Create;

public sealed class CreateItemRequest
{
    public string Name { get; init; } = default!;

    public string? Description { get; init; }

    public double? Value { get; init; }

    public ItemStatus Status { get; init; }
}