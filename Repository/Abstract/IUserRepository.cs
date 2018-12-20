using System;
using System.Collections.Generic;
using System.Text;
using Repository.Concrete;
using Repository.Models;

namespace Repository.Abstract
{
    public interface IUserRepository
    {
        ApplicationUser GetCurrentUser();
    }
}
