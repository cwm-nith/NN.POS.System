using MediatR;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class UpdateItemMasterImageCommandHandler(IWebHostEnvironment environment) : IRequestHandler<UpdateItemMasterImageCommand>
{
    public async Task Handle(UpdateItemMasterImageCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        if (r.File != null)
        {
            var uploadsPath = Path.Join(environment.WebRootPath, "contents/item-master/images");
            var filePath = Path.Join(uploadsPath, r.File.FileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            await using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await r.File.CopyToAsync(fileStream, cancellationToken);
        }
        else
        {
            throw new FileNotFoundException(r.ImageName);
        }
    }
}