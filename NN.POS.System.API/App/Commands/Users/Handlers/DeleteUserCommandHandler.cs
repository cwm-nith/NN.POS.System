using MediatR;
using NN.POS.System.API.Core.IRepositories.Users;

namespace NN.POS.System.API.App.Commands.Users.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return _userRepository.DeleteUserAsync(request.Id, cancellationToken);
    }
}