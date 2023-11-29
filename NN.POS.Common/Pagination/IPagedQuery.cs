namespace NN.POS.Common.Pagination;

public interface IPagedQuery
{
    int Page { get; set; }
    int Results { get; set; }
}