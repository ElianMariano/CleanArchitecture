using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Update;

public class UpdateItemHandler(
    ILogger<UpdateItemHandler> logger,
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
        item.Update(request.Name, request.Description, request.Value!.Value, request.Status);
        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogUpdateInformation(item.Id.Value);
        return new UpdateItemResponse(item.Id.Value);
    }
}