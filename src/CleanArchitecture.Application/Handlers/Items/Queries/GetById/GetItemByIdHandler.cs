using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Handlers.Items.Mappers;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.Handlers.Items.Queries.GetById;

public class GetItemByIdHandler(IItemRepository repository)
 : IApplicationHandler<GetItemByIdRequest, GetItemByIdResponse>
{
    public async Task<GetItemByIdResponse> Handle(
        GetItemByIdRequest request,
        CancellationToken cancellationToken)
    {
        Item? item = await repository.GetByIdAsync(new ItemId(request.ItemId), cancellationToken);
        if (item == null)
        {
            throw new ItemNotFoundException(request.ItemId);
        }
        return new GetItemByIdResponse(item.ToResponse());
    }
}