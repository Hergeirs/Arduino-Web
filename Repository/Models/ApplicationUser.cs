using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Repository.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public virtual List<Plant> Plants { get; set; }  
    }
}
