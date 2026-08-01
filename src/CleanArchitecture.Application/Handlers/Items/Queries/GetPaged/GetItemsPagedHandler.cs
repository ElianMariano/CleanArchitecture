using CleanArchitecture.Application.Handlers.Items.Mappers;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;

namespace CleanArchitecture.Application.Handlers.Items.Queries.GetPaged;

public class GetItemsPagedHandler(IItemRepository repository)
 : IApplicationHandler<GetItemsPagedRequest, GetItemsPagedResponse>
{
    public async Task<GetItemsPagedResponse> Handle(
        GetItemsPagedRequest request,
        CancellationToken cancellationToken)
    {
        var items = await repository.GetPagedAsync(request, cancellationToken);
        var data = items.Data!.Select(x => x.ToResponse()).ToList();
        return new GetItemsPagedResponse(data, items.TotalItems, request.CurrentPage, request.PageSize);
    }
}