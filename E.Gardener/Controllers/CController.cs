using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Repository.Concrete;
using Repository.Models;

namespace E.Gardener.Controllers
{
  public class CController : Controller
  {

 

    protected CController(UserManager<ApplicationUser> userManager)
    {
        this.UserManager = userManager;
    }

      public UserManager<ApplicationUser> UserManager { get; set; }


      protected async Task<ApplicationUser> CurrentUser() => await UserManager.GetUserAsync(User);
  }
}