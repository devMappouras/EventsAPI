using DataAccess.Models;
using DataAccess.Models.Auth;
using DataAccess.Models.Responses;
using EventsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers;

[ApiController]
[Route("EventsApi/[controller]/[action]")]
public class CustomersController : ControllerBase
{
    public static UserModel user = new UserModel();
    private readonly IConfiguration _configuration;
    private readonly ICustomersService _customersService;

    public CustomersController(ICustomersService CustomersService, IConfiguration configuration)
    {
        _customersService = CustomersService;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IResult> GetCustomers()
    {
        try
        {
            return Results.Ok(await _customersService.GetCustomers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetCustomerById(int CustomerId)
    {
        try
        {
            var result = await _customersService.GetCustomerById(CustomerId);
            if (result == null) return Results.NotFound();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> Register(CustomerModel Customer)
    {
        try
        {
            await _customersService.RegisterCustomer(Customer);
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
            var loginResponse = await _customersService.LoginCustomer(user);
            SetRefreshToken(loginResponse.RefreshTokenModel);
            return Results.Ok(new LoginCustomerResponse()
            {
                Token = loginResponse.Token,
                CustomerInfo = loginResponse.CustomerInfo
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
            
            var tokenResponse = await _customersService.RefreshToken(user);
            SetRefreshToken(tokenResponse.RefreshTokenModel);
            return Results.Ok(tokenResponse);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdateCustomer(CustomerModel Customer)
    {
        try
        {
            await _customersService.UpdateCustomer(Customer);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> DisableCustomer(int CustomerId)
    {
        try
        {
            await _customersService.DeleteCustomer(CustomerId);
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