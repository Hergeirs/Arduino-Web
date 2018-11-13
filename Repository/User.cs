using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public IEnumerable<Plant> Plants { get; set; }  
    }
}
