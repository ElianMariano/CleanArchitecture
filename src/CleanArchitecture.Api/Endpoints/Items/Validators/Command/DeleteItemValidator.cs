using CleanArchitecture.Application.Handlers.Items.Commands.Delete;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Validators.Command;

public class DeleteItemValidator : Validator<DeleteItemRequest>
{
    public DeleteItemValidator()
    {
        RuleFor(x => x.ItemId).ItemId();
    }
}