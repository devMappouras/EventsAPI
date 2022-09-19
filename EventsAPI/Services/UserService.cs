using System.IdentityModel.Tokens.Jwt;
using EventsAPI.Services.Interfaces;
using System.Security.Claims;
using System.Security.Cryptography;
using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Models.Enums;
using Microsoft.IdentityModel.Tokens;

namespace EventsAPI.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public UserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    public int GetLoggedInOrganiserId()
    {
        return _httpContextAccessor.HttpContext != null ? int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)) : 0;
    }

    public async Task<string> CreateToken(UserModel user, OrganiserModel? organiser)
    {
        var organiserRole = organiser?.RoleId != null ? organiser.RoleId.ToString() : "Basic";
        var organiserId = organiser?.OrganiserId != null ? organiser.OrganiserId.ToString() : "0";

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, organiserRole),
            new Claim(ClaimTypes.NameIdentifier, organiserId)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    public async Task<RefreshTokenModel> GenerateRefreshToken()
    {
        var refreshToken = new RefreshTokenModel
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(1),
            Created = DateTime.Now
        };
        return refreshToken;
    }
}