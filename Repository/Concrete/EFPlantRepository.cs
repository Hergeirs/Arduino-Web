using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFPlantRepository : IPlantRepository
    {

        public EFPlantRepository(EGardenerContext context)
        {

        }

        public IEnumerable<Plant> UserPlants(ApplicationUser user)
        {
            return user.Plants;
        }

        public bool SavePlant(Plant plant, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
