namespace NN.POS.Common.Pagination;

public class PagedQuery : IPagedQuery
{
    public int Page { get; set; } = 1;
    public int Results { get; set; } = 10;
}