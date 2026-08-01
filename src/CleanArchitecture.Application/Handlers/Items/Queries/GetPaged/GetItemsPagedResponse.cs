using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Handlers.Items.Queries.GetPaged;

public sealed class GetItemsPagedResponse(IReadOnlyList<ItemBase> Data, int TotalItems, int currentPage = 1, int pageSize = 12) : PagedResponseBase<ItemBase>(Data, TotalItems, currentPage, pageSize);