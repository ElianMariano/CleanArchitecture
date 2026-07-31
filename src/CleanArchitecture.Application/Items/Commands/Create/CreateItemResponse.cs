using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Items.Commands.Create;

public class CreateItemResponse(Guid itemId) : ResponseBase<Guid?>(itemId);