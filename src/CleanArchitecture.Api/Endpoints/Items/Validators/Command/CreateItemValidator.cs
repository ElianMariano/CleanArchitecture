using CleanArchitecture.Application.Handlers.Items.Commands.Create;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Validators.Command;

public class CreateItemValidator : Validator<CreateItemRequest>
{
    public CreateItemValidator()
    {
        RuleFor(x => x.Name).ItemName();

        RuleFor(x => x.Description).ItemDescription();

        RuleFor(x => x.Value).ItemValue();

        RuleFor(x => x.Status).ItemStatus();
    }
}