
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
            _context.Data.Add(data);
        }
    }
}
