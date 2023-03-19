using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class OrganisersController : ControllerBase
{
    public static UserModel user = new UserModel();
    private readonly IConfiguration _configuration;
    private readonly IOrganisersService _organisersService;

    public OrganisersController(IOrganisersService organisersService, IConfiguration configuration)
    {
        _organisersService = organisersService;
        _configuration = configuration;
    }

    [HttpGet, Authorize]
    public async Task<IResult> GetOrganisers()
    {
        try
        {
            return Results.Ok(await _organisersService.GetOrganisers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetOrganiserById(int OrganiserId)
    {
        try
        {
            var result = await _organisersService.GetOrganiserById(OrganiserId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> Register(OrganiserModel Organiser)
    {
        try
        {
            await _organisersService.RegisterOrganiser(Organiser);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IResult> Login(UserDto user)
    {
        try
        {
            var loginResponse = await _organisersService.LoginOrganiser(user);
            SetRefreshToken(loginResponse.RefreshTokenModel);
            return Results.Ok(new LoginResponse
            {
                Token = loginResponse.Token,
                OrganiserInfo = loginResponse.OrganiserInfo
            });
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IResult> RefreshToken()
    {
        try
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (!user.RefreshToken.Equals(refreshToken) || user.TokenExpires < DateTime.Now)
            {
                return Results.Unauthorized();
            }
            
            var tokenResponse = await _organisersService.RefreshToken(user);
            SetRefreshToken(tokenResponse.RefreshTokenModel);
            return Results.Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut, Authorize]
    public async Task<IResult> UpdateOrganiser(OrganiserModel Organiser)
    {
        try
        {
            await _organisersService.UpdateOrganiser(Organiser);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost, Authorize]
    public async Task<IResult> DisableOrganiser(int OrganiserId)
    {
        try
        {
            await _organisersService.DeleteOrganiser(OrganiserId);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    private void SetRefreshToken(RefreshTokenModel newRefreshToken)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = newRefreshToken.Expires
        };
        Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        user.RefreshToken = newRefreshToken.Token;
        user.TokenCreated = newRefreshToken.Created;
        user.TokenExpires = newRefreshToken.Expires;
    }
}