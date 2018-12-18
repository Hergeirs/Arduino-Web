using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repository.Models;

public interface IApplicationUserAccessor {
    Task<ApplicationUser> GetUser();
}

public class ApplicationUserAccessor : IApplicationUserAccessor {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _context;
    public ApplicationUserAccessor(UserManager<ApplicationUser> userManager, IHttpContextAccessor context) {
        _userManager = userManager;
        _context = context;
    }

    public Task<ApplicationUser> GetUser() {
        return _userManager.GetUserAsync(_context.HttpContext.User);
    }
}