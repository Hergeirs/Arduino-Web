using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Repository.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public IList<Plant> Plants { get; set; }  
    }
}
