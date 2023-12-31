using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController: ControllerBase{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService){
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request){
        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);  
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request){
        var authRequest = _authenticationService.Login(request.Email, request.Password);

        var response = new AuthenticationResponse(
            authRequest.User.Id,
            authRequest.User.FirstName,
            authRequest.User.LastName,
            authRequest.User.Email,
            authRequest.Token
        );
        return Ok(response);
    }
}