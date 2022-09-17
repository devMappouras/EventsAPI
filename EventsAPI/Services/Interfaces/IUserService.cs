using DataAccess.Models.Auth;

namespace EventsAPI.Services.Interfaces;

public interface IUserService
{
    string GetMyName();
    Task<string> CreateToken(UserModel user);
    Task<RefreshTokenModel> GenerateRefreshToken();
}