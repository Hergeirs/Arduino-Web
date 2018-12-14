using System.Threading.Tasks;
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
        
        protected Task<ApplicationUser> CurrentUser => _userManager.GetUserAsync(User);
    }
}