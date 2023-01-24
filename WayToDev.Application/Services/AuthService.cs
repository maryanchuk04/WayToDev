using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Application.Exceptions;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class AuthService : Dao<Account>, IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IPasswordHelper _passwordHelper;
    public AuthService(ApplicationContext context, 
        ITokenService tokenService, 
        IPasswordHelper passwordHelper, 
        IMapper mapper = null) 
        : base(context, mapper)
    {
        _tokenService = tokenService;
        _passwordHelper = passwordHelper;
    }
    
    public async Task<AuthenticateResponseModel> Authenticate(string email, string password)
    {
        var account = Context.Accounts
            .Include(x=>x.RefreshTokens)
            .Include(x=>x.Company)
            .Include(x=>x.User)
            .FirstOrDefault(x => x.Email == email);

        if (account == null)
        {
            throw new AuthenticateException("Incorrect login or password");
        }
        
        if (!_passwordHelper.VerifyPassword(password, account.Password))
        {
            throw new AuthenticateException("Incorrect login or password");
        }

        var jwtToken = _tokenService.GenerateAccessToken(account);
        var refreshToken = _tokenService.GenerateRefreshToken();

        account.RefreshTokens.Add(refreshToken);
        Update(account);
        await Context.SaveChangesAsync();
        return account.Company == null 
            ? new AuthenticateResponseModel(jwtToken, refreshToken.Token, Role.User) 
            : new AuthenticateResponseModel(jwtToken, refreshToken.Token, Role.Company);
    }

    public async Task<AuthenticateResponseModel> Registration(RegistrDto registrationDto)
    {
        if (Context.Accounts.Any(x=>x.Email == registrationDto.Email))
        {
            throw new AuthenticateException("Account already exist");
        }

        var newAccount = registrationDto.Role switch
        {
            Role.Company => RegistrationCompanyAccount(registrationDto.CompanyName ?? "", registrationDto.Email,
                registrationDto.Password),
            Role.User => RegistrationUserAccount(registrationDto.UserName ?? "", registrationDto.Email,
                registrationDto.Password),
            _ => throw new AuthenticateException("This role not exist")
        };
        
        var jwtToken = _tokenService.GenerateAccessToken(newAccount);
        var refreshToken = _tokenService.GenerateRefreshToken();
        newAccount.RefreshTokens.Add(refreshToken);
        Insert(newAccount);
        await Context.SaveChangesAsync();

        return new AuthenticateResponseModel(jwtToken, refreshToken.Token);
    }

    private Account RegistrationUserAccount(string userName, string email, string password)
    {
        return new Account
        {
            IsBlocked = false,
            Email = email,
            User = new User
            {
                UserName = userName,
                FirstName = userName,
                TechStack = new List<TechStack>()
            },
            RefreshTokens = new List<AccountToken>(),
            Password = _passwordHelper.HashPassword(password)
        };
    }

    private Account RegistrationCompanyAccount(string companyName, string email, string password)
    {
        return new Account
        {
            IsBlocked = false,
            Email = email,
            Company = new Company
            {
                CompanyName = companyName,
                TechStack = new List<TechStack>()
            },
            RefreshTokens = new List<AccountToken>(),
            Password = _passwordHelper.HashPassword(password)
        };
    }
}