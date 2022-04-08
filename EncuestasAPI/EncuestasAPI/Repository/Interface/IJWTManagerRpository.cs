using EncuestasAPI.Models;


namespace JWTWebAuthentication.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }

}