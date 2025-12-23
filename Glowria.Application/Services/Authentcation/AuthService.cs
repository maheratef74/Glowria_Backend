using System.Net;
using AutoMapper;
using Glowria.Application.Dtos;
using Glowria.Application.Shared;
using Glowria.Domain.IRepository;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Localization;
using RegisterRequest = Glowria.Application.Commands.Register.RegisterRequest;

namespace Glowria.Application.Services.Authentcation;

public class AuthService : IAuthService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IStringLocalizer<AuthService> _localizer;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public AuthService(ICustomerRepository customerRepository, IStringLocalizer<AuthService> localizer, IMapper mapper, ITokenService tokenService)
    {
        _customerRepository = customerRepository;
        _localizer = localizer;
        _mapper = mapper;
        _tokenService = tokenService;
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
        return Result<string>.Success(_localizer["Account created successfully"] , token);
    }

    public Task<Result<string>> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}