using CleanArchitecture.Application.Items.Commands.Create;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Commands;

public class CreateItemEndpoint : Endpoint<CreateItemRequest, CreateItemResponse>
{
    private readonly CreateItemHandler _handler;

    public CreateItemEndpoint(CreateItemHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Post(ItemRoutes.Route);

        Description(x =>
        {
            x.WithTags("Item");
        });

        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateItemRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _handler.Handle(request, cancellationToken);
        await Send.OkAsync(response);
    }
}