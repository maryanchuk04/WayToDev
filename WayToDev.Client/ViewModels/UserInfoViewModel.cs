using WayToDev.Core.Enums;

namespace WayToDev.Client.ViewModels;

/// <summary>
/// model for update all information about users
/// </summary>
public class UserInfoViewModel
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
    public string ImageUrl { get; set; }
    public List<TagViewModel> Tags { get; set; }
}