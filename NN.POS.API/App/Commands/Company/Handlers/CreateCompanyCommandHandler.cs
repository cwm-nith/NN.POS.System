using MediatR;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class CreateCompanyCommandHandler(ICompanyRepository repository, IWebHostEnvironment environment) : IRequestHandler<CreateCompanyCommand>
{
    public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;

        var logo = r.LogoFile == null ? "" : $"{Guid.NewGuid()}{Path.GetExtension(r.LogoFile?.FileName)}";

        await repository.CreateAsync(new CompanyDto
        {
            Address = r.Address,
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            IsDeleted = false,
            LocalCcyId = r.LocalCcyId,
            Location = r.Location,
            Logo = logo,
            Name = r.Name,
            PriceListId = r.PriceListId,
            SysCcyId = r.SysCcyId
        }, cancellationToken);

        if (!string.IsNullOrEmpty(logo) && r.LogoFile != null)
        {
            var uploadsPath = Path.Join(environment.WebRootPath, "contents/company");
            var filePath = Path.Join(uploadsPath, logo);
            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await r.LogoFile.CopyToAsync(fileStream, cancellationToken);
        }
    }
}