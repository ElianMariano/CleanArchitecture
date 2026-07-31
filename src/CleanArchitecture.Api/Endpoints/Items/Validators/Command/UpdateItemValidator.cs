using CleanArchitecture.Application.Items.Commands.Update;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Validators.Command;

public class UpdateItemValidator : Validator<UpdateItemRequest>
{
    public UpdateItemValidator()
    {
        RuleFor(x => x.ItemId).ItemId();

        RuleFor(x => x.Name).ItemName();

        RuleFor(x => x.Description).ItemDescription();

        RuleFor(x => x.Value).ItemValue();

        RuleFor(x => x.Status).ItemStatus();
    }
}