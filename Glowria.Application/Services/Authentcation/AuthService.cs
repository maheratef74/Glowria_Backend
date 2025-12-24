using System.Net;
using AutoMapper;
using Glowria.Application.Dtos;
using Glowria.Application.Shared;
using Glowria.Domain.IRepository;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Localization;
using LoginRequest = Glowria.Application.Commands.Login.LoginRequest;
using RegisterRequest = Glowria.Application.Commands.Register.RegisterRequest;

namespace Glowria.Application.Services.Authentcation;

public class AuthService : IAuthService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IStringLocalizer<AuthService> _localizer;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    public AuthService(ICustomerRepository customerRepository, IStringLocalizer<AuthService> localizer, IMapper mapper, ITokenService tokenService, UserManager<ApplicationUser> userManager)
    {
        _customerRepository = customerRepository;
        _localizer = localizer;
        _mapper = mapper;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<Result<string>> RegisterAsync(RegisterRequest request)
    {
        var existingCustomer = await _customerRepository.GetByEmail(request.Email);

        if (existingCustomer != null)
        {
            return Result<string>.Failure(_localizer["Email already exists"]);
        }

        var customer = _mapper.Map<Customer>(request);
        customer.UserName = request.Email;
        await _customerRepository.AddCustomer(customer, request.Password);
        
        var token = await _tokenService.GenerateToken(customer, false);
        return Result<string>.Success( token);
    }

    public async Task<Result<string>> LoginAsync(LoginRequest request)
    {
        var existUser = await _userManager.FindByEmailAsync(request.Email);
        var isCorrectPassword = existUser != null 
                                && await _userManager.CheckPasswordAsync(existUser, request.Password);
        
        if (existUser is null || !isCorrectPassword )
        {
            return Result<string>.Failure(_localizer["Invalid Credentials."] , HttpStatusCode.Forbidden);
        }
        var token = await _tokenService.GenerateToken(existUser, true);
        
        return Result<string>.Success(token);
    }
}