namespace WayToDev.Core.DTOs;

public class RegistrDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? UserName { get; set; }
    public string? CompanyName { get; set; }
    public Role Role { get; set; }
}