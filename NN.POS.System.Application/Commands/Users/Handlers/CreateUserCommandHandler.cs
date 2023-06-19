using MediatR;

namespace NN.POS.System.Application.Commands.Users.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(1);
    }
}