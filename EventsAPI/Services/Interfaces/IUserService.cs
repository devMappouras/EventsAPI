using DataAccess.Models;
using DataAccess.Models.Auth;

namespace EventsAPI.Services.Interfaces;

public interface IUserService
{
    int GetLoggedInOrganiserId();
    Task<string> CreateToken(UserModel user, OrganiserModel? organiser);
    Task<RefreshTokenModel> GenerateRefreshToken();
}