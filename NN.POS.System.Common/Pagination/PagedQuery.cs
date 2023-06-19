namespace NN.POS.System.Common.Pagination;

public class PagedQuery : IPagedQuery
{
    public PagedQuery(int page, int results)
    {
        Page = page;
        Results = results;
    }

    public int Page { get; }
    public int Results { get; }
}