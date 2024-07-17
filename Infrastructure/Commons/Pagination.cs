namespace RepositoryLayer.Commons
{
    public class Pagination<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public int PageIndex { get; set; }

        public int TotalPages
        {
            get
            {
                _TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

                return _TotalPages;
            }
            set
            {
                _TotalPages = value;
            }
        }

        private int _TotalPages { get; set; }

        public Pagination(List<T> items)
        {
            AddRange(items);
        }
    }
}