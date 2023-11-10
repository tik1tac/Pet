public abstract class QueryStringParametres
{
    const int MAXPAGESIZE = 50;
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value;
    }

    public string OrderBy { get; set; }

    public string Fields { get; set; }
}