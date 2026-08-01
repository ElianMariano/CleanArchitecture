using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Enumerations;
using FluentValidation;

namespace CleanArchitecture.Api.Endpoints.Items.Validators;

public static class ItemRules
{
    public static IRuleBuilderOptions<T, Guid> ItemId<T>(
        this IRuleBuilder<T, Guid> rule)
    {
        return rule.NotEmpty();
    }

    public static IRuleBuilderOptions<T, string> ItemName<T>(
        this IRuleBuilder<T, string> rule)
    {
        return rule
            .NotEmpty()
            .MaximumLength(ItemConstraints.NameMaxCharacters);
    }

    public static IRuleBuilderOptions<T, string?> ItemDescription<T>(
        this IRuleBuilder<T, string?> rule)
    {
        return rule.MaximumLength(ItemConstraints.DescriptionMaxCharacters);
    }

    public static IRuleBuilderOptions<T, double?> ItemValue<T>(
        this IRuleBuilder<T, double?> rule)
    {
        return rule.NotNull();
    }

    public static IRuleBuilderOptions<T, ItemStatus> ItemStatus<T>(
        this IRuleBuilder<T, ItemStatus> rule)
    {
        return rule.IsInEnum();
    }
}