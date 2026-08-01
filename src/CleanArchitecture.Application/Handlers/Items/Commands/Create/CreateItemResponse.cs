using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Create;

public class CreateItemResponse(Guid itemId) : ResponseBase<Guid?>(itemId);