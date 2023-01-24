namespace WayToDev.Core.DTOs;

public class AuthenticateResponseModel
{
    public AuthenticateResponseModel(string jwtToken, string refreshToken)
    {
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }

    public AuthenticateResponseModel(string jwtToken, string refreshToken, Role role)
    {
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
        Role = role;
    }

    public string JwtToken { get; set; }

    public string RefreshToken { get; set; }
    public Role? Role { get; set; }
}