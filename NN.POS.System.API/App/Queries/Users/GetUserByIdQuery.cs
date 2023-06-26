using MediatR;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Queries.Users;

public class GetUserByIdQuery:IRequest<UserDto>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}