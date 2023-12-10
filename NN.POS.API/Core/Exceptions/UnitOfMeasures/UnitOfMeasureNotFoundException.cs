namespace NN.POS.API.Core.Exceptions.UnitOfMeasures;

public class UnitOfMeasureNotFoundException(int id) : BaseException($"Unit of Measure with Id \"{id}\" could not be found.")
{
    public override string Code => "uom_nf";
}