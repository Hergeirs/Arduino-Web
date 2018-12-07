using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstract
{
    public interface IPlantRepository
    {
        IEnumerable<Plant> UserPlants(User user);
        bool SavePlant(Plant plant, User user);
    } 
}
