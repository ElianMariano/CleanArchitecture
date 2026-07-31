using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Items.Queries.GetPaged;

public sealed class GetItemsPagedResponse(IEnumerable<ItemBase> Data, int TotalItems, int currentPage = 1, int pageSize = 12) : PagedResponseBase<ItemBase>(Data, TotalItems, currentPage, pageSize);