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

    public AuthService(ApplicationContext context, ITokenService tokenService, IMapper mapper = null) 
        : base(context, mapper)
    {
        _tokenService = tokenService;
    }
    
    public async Task<AuthenticateResponseModel> Authenticate(string email, string password)
    {
        var account = Context.Accounts
            .Include(x=>x.User)
            .FirstOrDefault(x => x.User.Email == email);

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
        if (Context.Users.Any(x=>x.Email==registrationDto.Email))
        {
            throw new AuthenticateException("Account already exist");
        }

        var newAccount = new Account()
        {
            IsBlocked = false,
            User = new User
            {
                Email = registrationDto.Email,
                FirstName = registrationDto.UserName
            },
            RefreshTokens = new List<AccountToken>(),
            Password = HashPassword(registrationDto.Password)
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

    
}