using MediatR;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Queries.Users;

public class GetUserByNameQuery : IRequest<UserDto>
{
    public string Username { get; set; }

    public GetUserByNameQuery(string username)
    {
        Username = username;
    }
}