namespace HRManagement.SharedKarnel.Models
{
    /// <summary>
    /// Generic paginator list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
            => new PagedList<T>(source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(), source.Count(), pageNumber, pageSize);

        public static PagedResponse<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
            => new PagedResponse<T>(new PagedList<T>(source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(), source.Count(), pageNumber, pageSize));

        public static PagedResponse<T> ToPagedList(List<T> source, int total, int pageNumber, int pageSize)
            => new PagedResponse<T>(new PagedList<T>(source, total, pageNumber, pageSize));
    }

    public class PagedResponse<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public PagedList<T> Data { get; set; }

        public PagedResponse(PagedList<T> list)
        {
            Data = list;
            CurrentPage = list.CurrentPage;
            TotalPages = list.TotalPages;
            PageSize = list.PageSize;
            TotalCount = list.TotalCount;
            HasPreviousPage = list.HasPreviousPage;
            HasNextPage = list.HasNextPage;
        }
    }
}
