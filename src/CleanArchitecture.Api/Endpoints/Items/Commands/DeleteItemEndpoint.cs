using CleanArchitecture.Application.Items.Commands.Delete;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Commands;

public class DeleteItemEndpoint : Endpoint<DeleteItemRequest, DeleteItemResponse>
{
    private readonly DeleteItemHandler _handler;

    public DeleteItemEndpoint(DeleteItemHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Delete($"{ItemRoutes.Route}/{{itemId}}");

        Description(x =>
        {
            x.WithTags("Item");
        });

        AllowAnonymous();
    }

    public override async Task HandleAsync(
        DeleteItemRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _handler.Handle(request, cancellationToken);
        await Send.OkAsync(response);
    }
}