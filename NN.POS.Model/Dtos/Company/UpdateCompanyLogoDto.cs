namespace NN.POS.Model.Dtos.Company;

public class UpdateCompanyLogoDto : IBaseDto
{
    public string Logo { get; set; } = string.Empty;
    public FileData? LogoFile { get; set; }
}