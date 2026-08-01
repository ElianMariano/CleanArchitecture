using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Handlers.Items.Queries.GetById;

public class GetItemByIdResponse(ItemBase Data, int StatusCode = 200) : ResponseBase<ItemBase>(Data, StatusCode);