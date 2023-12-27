namespace NN.POS.API.Core.Exceptions.Company;

public class BranchNotFoundException(int id) : BaseException($"Branch with id \"{id}\" could not be found.")
{
    public override string Code => "br_nf";
}