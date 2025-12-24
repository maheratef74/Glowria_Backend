
using Glowria.Application.Commands.Login;
using Glowria.Application.Commands.Register;
using Glowria.Application.Services.Authentcation;
using Glowria.Application.Services.ResponseService;
using Microsoft.AspNetCore.Mvc;

namespace Glowria.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IResponseService _responseService;
    public AuthController(IAuthService authService, IResponseService responseService)
    {
        _authService = authService;
        _responseService = responseService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var response = await _authService.RegisterAsync(request);
        return _responseService.CreateResponse(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authService.LoginAsync(request);
        return _responseService.CreateResponse(response);
    }
}