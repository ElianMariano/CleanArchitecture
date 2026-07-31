using CleanArchitecture.Domain.Enumerations;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain;

public class Item
{
    public ItemId Id { get; private init; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public double Value { get; private set; }

    public ItemStatus Status { get; private set; }

    public DateTime CreatedAt { get; private init; }

    public Item(
        string name,
        string? description,
        double value,
        ItemStatus status)
    {
        this.Id = new ItemId(Guid.NewGuid());
        this.Name = name;
        this.Description = description;
        this.Value = value;
        this.Status = status;
        this.CreatedAt = DateTime.UtcNow;
        Validate();
    }

    public void Update(
        string name,
        string? description,
        double value,
        ItemStatus status)
    {
        this.Name = name;
        this.Description = description;
        this.Value = value;
        this.Status = status;
        Validate();
    }

    private void Validate()
    {
        if (this.Value < 0)
        {
            throw new BusinessException(DomainExceptionMessages.ITEM_NEGATIVE_VALUE);
        }
    }
}