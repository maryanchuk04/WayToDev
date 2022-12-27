using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WayToDev.Client.Controllers;

[Authorize]
public class UserController : ControllerBase
{
        
    public UserController()
    {
        
    }
    // TODO - get current user info method
    
}