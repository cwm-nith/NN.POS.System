namespace NN.POS.System.Common.Pagination;

public interface IPagedQuery
{
    int Page { get; }
    int Results { get; }
}