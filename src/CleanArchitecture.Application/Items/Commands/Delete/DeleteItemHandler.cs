using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Items.Commands.Delete;

public class DeleteItemHandler(
    ILogger<DeleteItemHandler> logger,
    IUnitOfWork unitOfWork,
    IItemRepository repository)
    : IApplicationHandler<DeleteItemRequest, DeleteItemResponse>
{
    public async Task<DeleteItemResponse> Handle(
        DeleteItemRequest request,
        CancellationToken cancellationToken)
    {
        Item? item = await repository.GetByIdAsync(new ItemId(request.ItemId), cancellationToken);
        if (item == null)
        {
            throw new ItemNotFoundException(request.ItemId);
        }
        repository.Delete(item, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogDeleteInformation(request.ItemId);
        return new DeleteItemResponse(null);
    }
}