using System.Security.Claims;
using NN.POS.Web.Models;

namespace NN.POS.Web.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        AuthenticateUser GetUser(List<Claim> claims);
    }
}
