using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Enumerations;
using CleanArchitecture.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Mappings;

public class ItemMapping : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable(nameof(Item));
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .HasConversion(id => id.Value, value => new ItemId(value));
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(ItemConstraints.NameMaxCharacters);
        builder.Property(c => c.Description)
            .HasMaxLength(ItemConstraints.DescriptionMaxCharacters);
        builder.Property(c => c.Status)
            .HasConversion(
                status => status.ToString(),
                status => Enum.Parse<ItemStatus>(status))
            .IsRequired()
            .HasMaxLength(ItemConstraints.StatusMaxCharacters);
        builder.Property(c => c.CreatedAt)
            .IsRequired();
    }
}