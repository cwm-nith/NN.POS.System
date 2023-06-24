namespace NN.POS.System.API.Commons.Pagination;

public interface IPagedQuery
{
    int Page { get; }
    int Results { get; }
}