using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Repository.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public IEnumerable<Plant> Plants { get; set; }  
    }
}
