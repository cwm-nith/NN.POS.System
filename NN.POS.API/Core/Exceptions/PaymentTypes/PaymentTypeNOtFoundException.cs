namespace NN.POS.API.Core.Exceptions.PaymentTypes;

public class PaymentTypeNotFoundException(int id) : BaseException($"Payment type with id \"{id}\" could not be found")
{
    public override string Code => "pmt_nf";
}