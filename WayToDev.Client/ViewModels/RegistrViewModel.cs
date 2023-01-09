using WayToDev.Core.DTOs;

namespace WayToDev.Client.ViewModels;

public class RegistrViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? UserName { get; set; }
    public string? CompanyName { get; set; }
    public Role Role { get; set; }
}