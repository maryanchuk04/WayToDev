using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WayToDev.Application.Exceptions;
using WayToDev.Domain.DTOs;
using WayToDev.Domain.Entities;
using WayToDev.Domain.Interfaces.DAOs;
using WayToDev.Domain.Interfaces.Services;

namespace WayToDev.Application.Services;

public class TokenService :  ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly ITokenDao _tokenDao;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IAccountDao _accountDao;

    public TokenService(IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper,
        ITokenDao tokenDao,
        IAccountDao accountDao)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _tokenDao = tokenDao;
        _accountDao = accountDao;
    }

    public string GenerateAccessToken(Account account)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, $"{account.Id}")
        };

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(30000),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public UserToken GenerateRefreshToken()
    {

        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return new UserToken
        {
            Token = Convert.ToBase64String(randomNumber),
            Expires = DateTime.Now.AddDays(7),
            Created = DateTime.Now,
        };
    }

    public async Task<AuthenticateResponseModel> RefreshToken(string token)
    {
        var account = _tokenDao.GetAccountByToken(token);
        if (account == null)
        {
            throw new AccountNotFoundException("Account with this token, not found");
        }

        var refreshToken = account.RefreshTokens.Single(x => x.Token == token);
        if (refreshToken.Expires < DateTime.Now && refreshToken.Revoked == null)
        {
            return null;
        }

        var newRefreshToken = GenerateRefreshToken();
        refreshToken.Revoked = DateTime.Now;
        refreshToken.ReplacedByToken = newRefreshToken.Token;
        account.RefreshTokens.Add(newRefreshToken);

        await _accountDao.Update(account);
        await _tokenDao.Update(refreshToken);
        // generate new jwt
        var jwtToken = GenerateAccessToken(account);
        return new AuthenticateResponseModel(jwtToken, newRefreshToken.Token);
    }

    public async Task<bool> RevokeToken(string token)
    {
        var refreshToken = _tokenDao.GetRefreshToken(token);

        if (refreshToken.Revoked == null && DateTime.UtcNow >= refreshToken.Expires)
        {
            return false;
        }

        refreshToken.Revoked = DateTime.Now;
        await _tokenDao.Update(refreshToken);
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete("refreshToken");
        return true;
    }
}