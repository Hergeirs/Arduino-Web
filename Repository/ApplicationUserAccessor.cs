using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repository.Models;

namespace Repository
{
    public interface IApplicationUserAccessor {
        Task<ApplicationUser> GetUser();
        Task<ApplicationUser> User { get; }
    }

    public class ApplicationUserAccessor : IApplicationUserAccessor {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _context;
        public ApplicationUserAccessor(UserManager<ApplicationUser> userManager, IHttpContextAccessor context) {
            _userManager = userManager;
            _context = context;
        }

        public Task<ApplicationUser> User => _userManager.GetUserAsync(_context.HttpContext.User);

        public Task<ApplicationUser> GetUser() {
            return _userManager.GetUserAsync(_context.HttpContext.User);
        }
    }
}