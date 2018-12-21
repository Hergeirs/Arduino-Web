
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFArduinoDataRepository : IArduinoDataRepository
    {
        private readonly EGardenerContext _context;
        
        public EFArduinoDataRepository(EGardenerContext context)
        {
            _context = context;
        }
        public void SaveData(ArduinoData data)
        {
            var context = _context;
            var plants = context.Plants.Include(x => x.Datas);
            var plant = plants.Single(x => x.PlantId == data.PlantId);
            var datas = plant.Datas;
            datas.Add(data);
            context.SaveChanges();
        }

    }
}
