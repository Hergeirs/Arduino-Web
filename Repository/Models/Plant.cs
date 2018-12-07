using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Repository.Models;

namespace Repository
{
    public class Plant
    {
        public uint PlantId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public User User { get; set; }
        public ICollection<ArduinoData> Datas { get; set; }
        //public int IdentityUserId { get; set; }
       
    }
}
