namespace CleanArchitecture.Contracts.DataTransferObjects;

public class PagedRequestBase(
    int currentPage = 1,
    int pageSize = 12)
{
    public int CurrentPage { get; set; } = currentPage;
    public int PageSize { get; set; } = pageSize;
}