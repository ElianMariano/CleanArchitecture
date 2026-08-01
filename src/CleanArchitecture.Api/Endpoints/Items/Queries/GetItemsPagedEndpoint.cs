using CleanArchitecture.Application.Handlers.Items.Queries.GetPaged;
using FastEndpoints;

namespace CleanArchitecture.Api.Endpoints.Items.Queries;

public class GetItemsPagedEndpoint : Endpoint<GetItemsPagedRequest, GetItemsPagedResponse>
{
    private readonly GetItemsPagedHandler _handler;

    public GetItemsPagedEndpoint(GetItemsPagedHandler handler)
    {
        _handler = handler;
    }

    public override void Configure()
    {
        Get(ItemRoutes.GetPaged);

        Description(x =>
        {
            x.WithTags("Item");
        });

        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetItemsPagedRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _handler.Handle(request, cancellationToken);
        await Send.OkAsync(response);
    }
}