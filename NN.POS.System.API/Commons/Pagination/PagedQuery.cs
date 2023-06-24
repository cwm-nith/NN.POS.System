namespace NN.POS.System.API.Commons.Pagination;

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