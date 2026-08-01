using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Delete;

public class DeleteItemResponse(Guid? itemId) : ResponseBase<Guid?>(itemId);