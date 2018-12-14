using System;
using System.Collections.Generic;
using System.Text;
using Repository.Models;

namespace Repository.Abstract
{
    public interface IPlantRepository
    {
        IList<Plant> UserPlants(ApplicationUser applicationUser);
        bool SavePlant(Plant plant, ApplicationUser applicationUser);
        bool SaveData(ArduinoData data);
    } 
}
