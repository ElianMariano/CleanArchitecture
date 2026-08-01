using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Application.Handlers.Items.Mappers;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Create;

public class CreateItemHandler(
    ILogger<CreateItemHandler> logger,
    IUnitOfWork unitOfWork,
    IItemRepository repository) : IApplicationHandler<CreateItemRequest, CreateItemResponse>
{
    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = request.ToDomain();
        await repository.AddAsync(item, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        logger.LogCreateInformation(item.Id.Value);
        return new CreateItemResponse(item.Id.Value);
    }
}