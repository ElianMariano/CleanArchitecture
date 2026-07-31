using CleanArchitecture.Application.Items.Mappers;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Contracts;

namespace CleanArchitecture.Application.Items.Commands.Create;

public class CreateItemHandler(
    IUnitOfWork unitOfWork,
    IItemRepository repository) : IApplicationHandler<CreateItemRequest, CreateItemResponse>
{
    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = request.ToDomain();
        await repository.AddAsync(item, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);
        return new CreateItemResponse(item.Id.Value);
    }
}