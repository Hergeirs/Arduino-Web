using System;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public double Humidity { get; set; }
        public int Temperature { get; set; }
        public double Light { get; set; }
        public User User { get; set; }
        //public int IdentityUserId { get; set; }
    }
}
