using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WayToDev.Application.Exceptions;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Enums;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class TokenService :  Dao<AccountToken>, ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPinGenerator _pinGenerator;
    
    public TokenService(ApplicationContext context,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor, IPinGenerator pinGenerator, IMapper mapper = null)
        : base(context, mapper)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _pinGenerator = pinGenerator;
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

    public AccountToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return new AccountToken
        {
            Token = Convert.ToBase64String(randomNumber),
            Expires = DateTime.Now.AddDays(7),
            Created = DateTime.Now,
        };
    }

    public async Task<AuthenticateResponseModel> RefreshToken(string token)
    {
        var account = Context.Accounts
            .Include(a => a.RefreshTokens)
            .SingleOrDefault(a => a.RefreshTokens.Any(t => t.Token.Equals(token)));

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

        Context.Update(account);
        Update(refreshToken);
        await Context.SaveChangesAsync();

        // generate new jwt
        var jwtToken = GenerateAccessToken(account);
        return new AuthenticateResponseModel(jwtToken, newRefreshToken.Token);
    }

    public async Task<bool> RevokeToken(string token)
    {
        var refreshToken = Context.AccountTokens.SingleOrDefault(x => x.Token == token);
        if (refreshToken == null)
        {
            throw new TokenException("Refresh token is not exist");
        }

        if (refreshToken.Revoked == null && DateTime.UtcNow >= refreshToken.Expires)
        {
            return false;
        }

        refreshToken.Revoked = DateTime.Now;
        Update(refreshToken);
        await Context.SaveChangesAsync();

        _httpContextAccessor.HttpContext?.Response.Cookies.Delete("refreshToken");
        return true;
    }

    public async Task<AccountToken> GenerateEmailConfirmationToken(Guid accountId)
    {
        var emailToken = new AccountToken()
        {
            Token = _pinGenerator.Generate().ToString(),
            Expires = DateTime.Now.AddDays(7),
            Created = DateTime.Now,
            AccountId = accountId,
            Type = TokenType.EmailConfirmationType
        };

        Context.AccountTokens.Add(emailToken);

        await Context.SaveChangesAsync();

        return emailToken;
    }
}