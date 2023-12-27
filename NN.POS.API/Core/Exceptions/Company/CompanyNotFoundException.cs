namespace NN.POS.API.Core.Exceptions.Company;

public class CompanyNotFoundException(int id) : BaseException($"Company with id \"{id}\" could not be found.")
{
    public override string Code => "com_nf";
}