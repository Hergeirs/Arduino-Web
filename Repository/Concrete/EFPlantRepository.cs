using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFPlantRepository : IPlantRepository
    {

        private EGardenerContext _context;

        public EFPlantRepository(EGardenerContext context)
        {
            _context = context;
        }

        public IList<Plant> UserPlants(ApplicationUser applicationUser)
        {
            return applicationUser.Plants;
        }

        public bool SavePlant(Plant plant, ApplicationUser applicationUser)
        {
            if (applicationUser != null && plant != null)
            {
                applicationUser.Plants.Add(plant);
                _context.Plants.Add(plant);
                return true;
            }
            return false;
        }

        public bool SaveData(Plant plant, ArduinoData data)
        {
            return false;
            //plant.
        }
    }
}
