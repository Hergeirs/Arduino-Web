using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstract;

namespace Repository.Concrete
{
    public class EFPlantRepository : IPlantRepository
    {

        public EFPlantRepository(EGardenerContext context)
        {

        }

        public IEnumerable<Plant> UserPlants(User user)
        {
            return user.Plants;
        }

        public bool SavePlant(Plant plant, User user)
        {
            throw new NotImplementedException();
        }
    }
}
