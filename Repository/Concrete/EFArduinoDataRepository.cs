
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
            ArduinoData dbEntry = _context.Data.Find(data.DataId);

            if (dbEntry != null)
            {
                dbEntry.Plant = data.Plant;
                dbEntry.Light = data.Light;
                dbEntry.Moisture = data.Moisture;
                dbEntry.Temperature = data.Temperature;
                dbEntry.Water = data.Water;
            }
            _context.Data.Add(data);
        }
    }
}
