using Microsoft.AspNetCore.Http;

namespace NN.POS.Model.Dtos.ItemMasters;

public class UpdateItemMasterImageDto
{
    public string? ImageName { get; set; }
    public IFormFile? File { get; set; }
}