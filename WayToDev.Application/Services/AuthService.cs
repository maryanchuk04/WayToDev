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
    private readonly IMailService _mailService;
    private readonly IPasswordHelper _passwordHelper;
    
    public AuthService(
        ApplicationContext context,
        ITokenService tokenService,
        IPasswordHelper passwordHelper,
        IMailService mailService,
        IMapper mapper
        ) : base(context, mapper)
    {
        _tokenService = tokenService;
        _passwordHelper = passwordHelper;
        _mailService = mailService;
    }
    
    public async Task<AuthenticateResponseModel> AuthenticateAsync(string email, string password)
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

    public async Task<string> RegistrationAsync(RegistrDto registrationDto)
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
        
        var acc = Insert(newAccount);
        var res = await _tokenService.GenerateEmailConfirmationToken(acc.Id);
        await _mailService.SendRegistrationMessageAsync(registrationDto.Email, res.Token);
        
        await Context.SaveChangesAsync();
        
        
        return res.AccountId.ToString();
    }

    public async Task<AuthenticateResponseModel> EmailConfirmAndAuthenticateAsync(string token, Guid accountId)
    {
        var account = await _tokenService.VerifyEmailConfirmationTokenAsync(accountId, token);
        account.IsBlocked = false;
        var jwtToken = _tokenService.GenerateAccessToken(account);
        var refreshToken = _tokenService.GenerateRefreshToken();
        await Context.SaveChangesAsync();

        return account.Company == null 
            ? new AuthenticateResponseModel(jwtToken, refreshToken.Token, Role.User) 
            : new AuthenticateResponseModel(jwtToken, refreshToken.Token, Role.Company);
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