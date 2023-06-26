using MediatR;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Queries.Users;

public class GetUserByEmailQuery : IRequest<UserDto>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}