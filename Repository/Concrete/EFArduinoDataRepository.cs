
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFArduinoDataRepository : IArduinoDataRepository
    {
        private EGardenerContext _context;

        public EFArduinoDataRepository(EGardenerContext context)
        {
            _context = context;
        }

        public void SaveData(ArduinoData data)
        {
            // Plant plant = _context.Plants.Find(data.Plant.PlantId);

            data.Plant = new Plant
            {
                PlantId = 1,
                User = new ApplicationUser(),
                Name = "Slayer",
                Datas = new List<ArduinoData>(4),
                DateAdded = DateTime.Now
            };

            data.Plant.Datas.Add(data);



            //plant.Datas.Add(data);
            _context.Data.Add(data);
        }
    }
}

