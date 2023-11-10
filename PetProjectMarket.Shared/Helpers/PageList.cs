using PetProjectMarket.Shared.Helpers;

public class PageList<T> : List<T>
{
    public Metadata Metadata { get; set; }
    public PageList(List<T> _items, int _count, int _pagenumber, int _pagesize)
    {
        Metadata = new()
        {
            TotalCount = _count,
            PageSize = _pagesize,
            CurrentPage = _pagenumber,
            TotalPages = (int)Math.Ceiling(_count / (double)_pagesize)
        };


        AddRange(_items);
    }
    public static PageList<T> ToPageList(List<T> parametr, int pagenumber, int pagesize)
    {
        int count = parametr.Count;
        var items = parametr.Skip((pagenumber - 1) * pagesize).Take(pagesize).ToList();

        return new PageList<T>(items, count, pagenumber, pagesize);
    }
}