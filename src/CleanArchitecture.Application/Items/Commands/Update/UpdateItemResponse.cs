using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Items.Commands.Update;

public class UpdateItemResponse(Guid itemId) : ResponseBase<Guid?>(itemId);