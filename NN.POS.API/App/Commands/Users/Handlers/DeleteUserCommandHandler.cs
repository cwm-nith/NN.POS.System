using MediatR;
using NN.POS.API.Core.IRepositories.Users;

namespace NN.POS.API.App.Commands.Users.Handlers;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await userRepository.DeleteUserAsync(request.Id, cancellationToken);
    }
}