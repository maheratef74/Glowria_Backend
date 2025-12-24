using Glowria.Application.Dtos;
using Glowria.Application.Shared;
using Microsoft.AspNetCore.Identity.Data;
using LoginRequest = Glowria.Application.Commands.Login.LoginRequest;
using RegisterRequest = Glowria.Application.Commands.Register.RegisterRequest;

namespace Glowria.Application.Services.Authentcation;

public interface IAuthService
{
    Task<Result<string>> RegisterAsync(RegisterRequest request);
    Task<Result<string>> LoginAsync(LoginRequest request);
}