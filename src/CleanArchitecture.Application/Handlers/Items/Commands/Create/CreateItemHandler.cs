using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Create;

public class CreateItemHandler(
    ILogger<CreateItemHandler> logger,
    IUnitOfWork unitOfWork,
    IItemRepository repository) : IApplicationHandler<CreateItemRequest, CreateItemResponse>
{
    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = new Item(request.Name, request.Description, request.Value!.Value, request.Status);
        await repository.AddAsync(item, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogCreateInformation(item.Id.Value);
        return new CreateItemResponse(item.Id.Value);
    }
}