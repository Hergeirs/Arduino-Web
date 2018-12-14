using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Repository.Models;

namespace Repository
{
    public static class UserManager
    {
        public static ApplicationUser Current => System.Web.HttpContext.Current.GetOwinContext().GetUserManager
}
