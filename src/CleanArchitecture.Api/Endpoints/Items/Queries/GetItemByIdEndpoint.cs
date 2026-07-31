using CleanArchitecture.Application.Items.Queries.GetById;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Queries;

public class GetItemByIdEndpoint : Endpoint<GetItemByIdRequest, GetItemByIdResponse>
{
    private readonly GetItemByIdHandler _handler;

    public GetItemByIdEndpoint(GetItemByIdHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get(ItemRoutes.Route);

        Description(x =>
        {
            x.WithTags("Item");
        });

        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetItemByIdRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _handler.Handle(request, cancellationToken);
        await Send.OkAsync(response);
    }
}