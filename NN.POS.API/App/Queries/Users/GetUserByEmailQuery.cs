using MediatR;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Queries.Users;

public class GetUserByEmailQuery : IRequest<UserDto>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}