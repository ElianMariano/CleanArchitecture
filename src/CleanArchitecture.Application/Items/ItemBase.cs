using CleanArchitecture.Domain.Enumerations;

namespace CleanArchitecture.Application.Items;

public class ItemBase
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public double Value { get; set; }

    public ItemStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}