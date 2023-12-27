namespace NN.POS.API.Core.Exceptions.Warehouses;

public class WarehouseNotFoundException(int id) : BaseException($"Warehouse with id \"{id}\" could not be found.")
{
    public override string Code => "ws_nf";
}