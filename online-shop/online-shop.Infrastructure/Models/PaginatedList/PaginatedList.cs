using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Infrastructure.Models.PaginatedList
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> PageData { get; private set; }
        public int PagesCount { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        
        public bool HasPreviousPage => (PageNumber > 1);
        public bool HasNextPage => (PageNumber < PagesCount);

        public PaginatedList(IEnumerable<T> items, int pageNumber, int pagesCount)
        {
            PageNumber = pageNumber;
            PageSize = items.Count();
            PagesCount = pagesCount;
            PageData = items;
        }
    }
}