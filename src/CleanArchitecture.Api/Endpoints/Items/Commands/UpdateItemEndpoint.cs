using CleanArchitecture.Application.Items.Commands.Update;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Commands;

public class UpdateItemEndpoint : Endpoint<UpdateItemRequest, UpdateItemResponse>
{
    private readonly UpdateItemHandler _handler;

    public UpdateItemEndpoint(UpdateItemHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Put(ItemRoutes.Route);

        Description(x =>
        {
            x.WithTags("Item");
        });

        AllowAnonymous();
    }

    public override async Task HandleAsync(
        UpdateItemRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _handler.Handle(request, cancellationToken);
        await Send.OkAsync(response);
    }
}