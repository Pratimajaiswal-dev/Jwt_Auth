using Jwt_Auth.Models;
using Jwt_Auth.RequestModels;

namespace Jwt_Auth.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}


