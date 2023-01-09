using AutoMapper;
using WayToDev.Application.Exceptions;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class AuthService : Dao<Account>, IAuthService
{
    private readonly ITokenService _tokenService;

    public AuthService(ApplicationContext context, ITokenService tokenService, IMapper mapper = null) 
        : base(context, mapper)
    {
        _tokenService = tokenService;
    }
    
    public async Task<AuthenticateResponseModel> Authenticate(string email, string password)
    {
        var account = Context.Accounts
            .FirstOrDefault(x => x.Email == email);

        if (account == null)
        {
            throw new AuthenticateException("Incorrect login or password");
        }
        
        if (!VerifyPassword(password, account.Password))
        {
            throw new AuthenticateException("Incorrect login or password");
        }

        var jwt = _tokenService.GenerateAccessToken(account);
        var refreshToken = _tokenService.GenerateRefreshToken();

        account.RefreshTokens.Add(refreshToken);
        Update(account);
        await Context.SaveChangesAsync();
        return new AuthenticateResponseModel(jwt, refreshToken.Token);
    }

    public async Task<AuthenticateResponseModel> Registration(RegistrDto registrationDto)
    {
        if (Context.Accounts.Any(x=>x.Email==registrationDto.Email))
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
    
    private bool VerifyPassword(string passwordFromRequest, string password) => BCrypt.Net.BCrypt.Verify(passwordFromRequest,password);

    private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    private Account RegistrationUserAccount(string userName, string email, string password)
    {
        return new Account
        {
            IsBlocked = false,
            Email = email,
            User = new User
            {
                FirstName = userName
            },
            RefreshTokens = new List<AccountToken>(),
            Password = HashPassword(password)
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
            },
            RefreshTokens = new List<AccountToken>(),
            Password = HashPassword(password)
        };
    }
}