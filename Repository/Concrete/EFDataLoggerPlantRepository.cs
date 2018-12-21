using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
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


        public async void SavePlantData(ArduinoData data)
        {
            var plant = _context.Plants.Include(x => x.Datas).Single(x => x.PlantId == data.PlantId);
            plant.Datas.Add(data);
            _context.SaveChanges();

        }
    }
}
