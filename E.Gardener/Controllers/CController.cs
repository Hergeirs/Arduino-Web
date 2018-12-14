using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace E.Gardener.Controllers
{
    public class CController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        protected CController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        protected ApplicationUser CurrentUser => new ApplicationUser();//await _userManager.GetUserAsync(User);
    }
}