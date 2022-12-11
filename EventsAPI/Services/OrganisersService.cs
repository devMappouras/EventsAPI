using System.Security.Cryptography;
using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using DataAccess.Repositories.Interfaces;
using DataAccess.Models;
using DataAccess.Models.Auth;

namespace EventsAPI.Services;

public class OrganisersService : IOrganisersService
{
    private readonly IOrganisersRepository _organisersRepository;
    private readonly IUserService _userService;

    public OrganisersService(IOrganisersRepository organisersRepository, IUserService userService)
    {
        _organisersRepository = organisersRepository;
        _userService = userService;
    }

    public async Task<IEnumerable<GetOrganisersResponse>> GetOrganisers()
    {
        return await _organisersRepository.GetOrganisers();
    }

    public async Task<OrganiserModel> GetOrganiserById(int id)
    {
        return await _organisersRepository.GetOrganiserById(id);
    }

    public async Task RegisterOrganiser(OrganiserModel Organiser)
    {
        CreatePasswordHash(Organiser.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //Organiser.Password = System.Text.Encoding.UTF8.GetString(passwordHash);
        //Organiser.PasswordSalt = System.Text.Encoding.UTF8.GetString(passwordSalt);
        Organiser.Password = Convert.ToBase64String(passwordHash);
        Organiser.PasswordSalt = Convert.ToBase64String(passwordSalt);
        
        await _organisersRepository.RegisterOrganiser(Organiser);
    }
    
    public async Task<LoginOrganiserResponse> LoginOrganiser(UserDto user)
    {
        var OrganiserInfo = await _organisersRepository.GetOrganiserInfoByUsername(user.Email);

        if (OrganiserInfo == null)
            throw new Exception("User was not Found");

        var encodedPasswordHash = Convert.FromBase64String(OrganiserInfo.Password);
        var encodedPasswordSalt = Convert.FromBase64String(OrganiserInfo.PasswordSalt);

        if (!VerifyPasswordHash(user.Password, encodedPasswordHash, encodedPasswordSalt))
            throw new Exception("Wrong Password");

        var userModel = new UserModel();
        userModel.Email = user.Email;
        userModel.PasswordHash = encodedPasswordHash;
        userModel.PasswordSalt = encodedPasswordSalt;
        
        var token = _userService.CreateToken(userModel, OrganiserInfo);
        var refreshToken = _userService.GenerateRefreshToken();

        return new LoginOrganiserResponse
        {
            Token = token.Result,
            RefreshTokenModel = refreshToken.Result,
            OrganiserInfo = new GetOrganisersResponse
            {
                Email = OrganiserInfo.Email,
                Name = OrganiserInfo.Name,
                Location = OrganiserInfo.Location,
                Logo = OrganiserInfo.Logo,
                RoleId = OrganiserInfo.RoleId
            }
        };
    }

    public async Task<LoginOrganiserResponse> RefreshToken(UserModel user)
    {
        var organiserInfo = await _organisersRepository.GetOrganiserInfoByUsername(user.Email);
        var token = _userService.CreateToken(user, organiserInfo);
        var newRefreshToken = _userService.GenerateRefreshToken();
        return new LoginOrganiserResponse
        {
            Token = token.Result,
            RefreshTokenModel = newRefreshToken.Result,
            OrganiserInfo = new GetOrganisersResponse
            {
                Email = organiserInfo.Email,
                Name = organiserInfo.Name,
                Location = organiserInfo.Location,
                Logo = organiserInfo.Logo,
                RoleId = organiserInfo.RoleId
            }
        };
    }    
    
    public async Task UpdateOrganiser(OrganiserModel Organiser)
    {
        await _organisersRepository.UpdateOrganiser(Organiser);
    }

    public async Task DeleteOrganiser(int OrganisersId)
    {
        await _organisersRepository.DeleteOrganiser(OrganisersId);
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}