namespace NN.POS.API.Core.Exceptions.UnitOfMeasures;

public class UnitOfMeasureDefineNotFoundException(int id) : BaseException($"Unit of Measure Define with Id \"{id}\" could not be found.")
{
    public override string Code => "uom_df_nf";
}