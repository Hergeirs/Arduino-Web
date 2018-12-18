using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFPlantRepository : IPlantRepository
    {

        private readonly EGardenerContext _context;

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
                //_context.Users.Find(applicationUser).Plants.Add(plant);
                _context.Plants.Add(plant);
                return true;
            }
            return false;
        }

        public bool SaveData(Plant plant, ArduinoData data)
        {
            if (plant != null)
            {
                plant.Datas.Add(data);
                return true;
            }
            return false;
        }
    }
}
