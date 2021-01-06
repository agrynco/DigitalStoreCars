namespace Services.DTOs
{
    public class PagedResult<TItem>
    {
        public PagedResult(TItem[] items, int totalPages)
        {
            Items = items;
            TotalPages = totalPages;
        }

        public TItem[] Items { get; }
        public int TotalPages { get; }
    }
}