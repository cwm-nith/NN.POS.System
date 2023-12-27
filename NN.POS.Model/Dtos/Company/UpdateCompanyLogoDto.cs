using Microsoft.AspNetCore.Http;

namespace NN.POS.Model.Dtos.Company;

public class UpdateCompanyLogoDto : IBaseDto
{
    public string Logo { get; set; } = string.Empty;
    public IFormFile? LogoFile { get; set; }
}