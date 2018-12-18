
using System.Net.Mime;
using System.Security.Claims;
using System.ServiceProcess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Microsoft.AspNetCore.Owin;
using Microsoft.AspNetCore.Identity;
using Repository;
using System.Security.Claims;


public static class UserHelper
{
//    private readonly IHttpContextAccessor _httpContextAccessor;
//
//    public UserHelper(IHttpContextAccessor httpContextAccessor)
//    {
//        _httpContextAccessor = httpContextAccessor;
//    }


    public static ApplicationUser CurrentUser(this Controller controller)
    {
        return UserManager;
    }
    
//    public ApplicationUser CurrentApplicationUser()
//    {
//        User.FindFirst(ClaimTypes.NameIdentifier).Value;
//    }
    
}
