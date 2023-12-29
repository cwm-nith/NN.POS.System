using MediatR;
using NN.POS.API.Core.IRepositories.Company;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class UpdateCompanyLogoCommandHandler(ICompanyRepository repository, IWebHostEnvironment environment) : IRequestHandler<UpdateCompanyLogoCommand>
{
    public async Task Handle(UpdateCompanyLogoCommand request, CancellationToken cancellationToken)
    {
        var com = await repository.GetByIdAsync(request.Id, cancellationToken);

        var r = request.Dto;
        
        if (r.LogoFile is not null)
        {
            var logo = $"{Guid.NewGuid()}{Path.GetExtension(r.LogoFile.FileName)}";

            com.Logo = logo;

            await repository.UpdateAsync(com, cancellationToken);

            var uploadsPath = Path.Join(environment.WebRootPath, "contents/company");
            var filePath = Path.Join(uploadsPath, logo);
            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await fileStream.WriteAsync(r.LogoFile.ImageBytes, cancellationToken);

            var oldLogo = r.Logo.Split('\\')[^1];

            var extPath = Path.Join(environment.WebRootPath, $"contents/company/{oldLogo}");
            File.Delete(extPath);
        }
    }
}