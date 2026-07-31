using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Items.Commands.Delete;

public class DeleteItemResponse(Guid itemId) : ResponseBase<Guid?>(itemId);