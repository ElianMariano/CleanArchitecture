using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Application.Items.Queries.GetPaged;

public sealed class GetItemsPagedRequest(int currentPage = 1, int pageSize = 12) : PagedRequestBase(currentPage, pageSize);