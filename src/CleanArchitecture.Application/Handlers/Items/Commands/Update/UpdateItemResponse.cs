using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Handlers.Items.Commands.Update;

public class UpdateItemResponse(Guid itemId) : ResponseBase<Guid?>(itemId);