using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Concrete
{
    public class EFDataLoggerPlantRepository
    {
        private readonly EGardenerContext _context;

        public EFDataLoggerPlantRepository(EGardenerContext context)
        {
            _context = context;
        }


        public void SavePlantData(ArduinoData data)
        {
            var plantQueryable = _context.Plants
                .Include(x => x.Datas);
                var plant = plantQueryable.Single(x => x.PlantId == data.PlantId);
                plant.Datas.Add(data);
                _context.SaveChanges();
        }
    }
}
