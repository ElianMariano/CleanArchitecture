using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.Items.Commands.Update;

public class UpdateItemHandler(
    IUnitOfWork unitOfWork,
    IItemRepository repository)
 : IApplicationHandler<UpdateItemRequest, UpdateItemResponse>
{
    public async Task<UpdateItemResponse> Handle(
        UpdateItemRequest request,
        CancellationToken cancellationToken)
    {
        Item? item = await repository.GetByIdAsync(new ItemId(request.ItemId), cancellationToken);
        if (item == null)
        {
            throw new ItemNotFoundException(request.ItemId);
        }
        item.Update(request.Name, request.Description, request.Value, request.Status);
        await unitOfWork.CommitAsync(cancellationToken);
        return new UpdateItemResponse(item.Id.Value);
    }
}