using NN.POS.Model.Enums;

namespace NN.POS.Model.Dtos.PriceLists;

public class UpdatePriceListDetailDto
{
    public decimal Cost { get; set; } // purchase price
    public decimal Price { get; set; } // sale price
}