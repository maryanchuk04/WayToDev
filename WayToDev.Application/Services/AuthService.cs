using WayToDev.Application.Exceptions;
using WayToDev.Domain.DTOs;
using WayToDev.Domain.Entities;
using WayToDev.Domain.Interfaces.DAOs;
using WayToDev.Domain.Interfaces.Services;

namespace WayToDev.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IAccountDao _accountDao;

    public AuthService(ITokenService tokenService, IAccountDao accountDao)
    {
        _tokenService = tokenService;
        _accountDao = accountDao;
    }

    public async Task<AuthenticateResponseModel> Authenticate(string email, string password)
    {
        var account = _accountDao.FindByEmail(email);

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
        await _accountDao.Update(account);
        return new AuthenticateResponseModel(jwt, refreshToken.Token);
    }

    public async Task<AuthenticateResponseModel> Registration(RegistrDto registrationDto)
    {
        if (_accountDao.IsExist(registrationDto.Email))
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
            RefreshTokens = new List<UserToken>(),
            Password = HashPassword(registrationDto.Password)
        };
        var jwtToken = _tokenService.GenerateAccessToken(newAccount);
        var refreshToken = _tokenService.GenerateRefreshToken();
        newAccount.RefreshTokens.Add(refreshToken);
        await _accountDao.Create(newAccount);
        return new AuthenticateResponseModel(jwtToken, refreshToken.Token);
    }
    
    private bool VerifyPassword(string passwordFromRequest, string password) => BCrypt.Net.BCrypt.Verify(passwordFromRequest,password);

    private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
}