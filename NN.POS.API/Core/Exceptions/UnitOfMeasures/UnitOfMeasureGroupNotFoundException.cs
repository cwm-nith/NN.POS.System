namespace NN.POS.API.Core.Exceptions.UnitOfMeasures;

public class UnitOfMeasureGroupNotFoundException(int id) : BaseException($"Unit of Measure Group with Id \"{id}\" could not be found.")
{
    public override string Code => "uom_g_nf";
}