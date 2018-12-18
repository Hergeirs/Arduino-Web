using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using Repository.Models;

namespace Repository.Abstract
{
    public interface IPlantRepository
    {
        IEnumerable<Plant> UserPlants(ApplicationUser user);
        bool SavePlant(Plant plant, ApplicationUser user);
    } 
}
