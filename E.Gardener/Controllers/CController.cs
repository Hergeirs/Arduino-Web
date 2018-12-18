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

 

    protected CController(UserManager<User> userManager)
    {
        this.UserManager = userManager;
    }

      private UserManager<User> UserManager { get; set; }


      public Task<User> CurrentUser => UserManager.GetUserAsync(User);
  }
}