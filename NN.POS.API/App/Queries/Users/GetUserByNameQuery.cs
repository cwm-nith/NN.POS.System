using MediatR;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Queries.Users;

public class GetUserByNameQuery : IRequest<UserDto>
{
    public string Username { get; set; }

    public GetUserByNameQuery(string username)
    {
        Username = username;
    }
}