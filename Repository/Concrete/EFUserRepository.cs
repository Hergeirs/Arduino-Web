using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EGardenerContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EFUserRepository(EGardenerContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public ApplicationUser GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _context.Users.Single(x => x.Id == userId);
        }
    }
}