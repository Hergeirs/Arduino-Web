using Repository.Models;

namespace Repository.Abstract
{
    public interface IUserRepository
    {
        ApplicationUser GetCurrentUser();
    }
}
