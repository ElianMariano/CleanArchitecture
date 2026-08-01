using CleanArchitecture.Application.Handlers.Items.Queries.GetById;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Validators.Command;

public class GetItemByIdValidator : Validator<GetItemByIdRequest>
{
    public GetItemByIdValidator()
    {
        RuleFor(x => x.ItemId).ItemId();
    }
}