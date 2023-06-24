using MediatR;
using NN.POS.System.API.Core.Dtos.Users;

namespace NN.POS.System.API.App.Queries.Users;

public class GetUserByNameQuery : IRequest<UserDto>
{
    public string Username { get; set; }

    public GetUserByNameQuery(string username)
    {
        Username = username;
    }
}