namespace CleanArchitecture.Contracts.DataTransferObjects;

public class PagedResponseBase<T>(
    IEnumerable<T> data,
    int totalItems,
    int currentPage = 1,
    int pageSize = 12
)
{
    public int TotalPages => (int)Math.Ceiling((double) TotalItems / PageSize);

    public bool HasNext => CurrentPage < TotalPages;

    public bool HasPrevious => CurrentPage > 1;

    public int TotalItems { get; set; } = totalItems;

    public IEnumerable<T> Data { get; set; } = data;

    public int CurrentPage { get; set; } = currentPage;

    public int PageSize { get; set; } = pageSize;
}