namespace BookFetcher.API.Models
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public Pagination()
        {
            CurrentPage = 1;
            PageSize = 10;
        }

        public Pagination(int currentPage, int pageSize)
        {
            CurrentPage = currentPage < 1 ? 1 : currentPage;
            PageSize = pageSize < 10 ? 10 : pageSize;
        }

        public void SetDefaults()
        {
            CurrentPage = CurrentPage < 1 ? 1 : CurrentPage;
            PageSize = PageSize < 10 ? 10 : PageSize;
        }
    }
}
