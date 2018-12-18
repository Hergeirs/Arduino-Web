using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ArduinoObserver;
using Repository.Concrete;
using Repository.Models;

namespace E.Gardener.Controllers
{
    public class HomeController : CController
    {
        private readonly Observer _dataLogger;
        private readonly EGardenerContext _context;

        public HomeController(Observer logger, EGardenerContext context, UserManager<ApplicationUser> userManager) : base(userManager)
        {
            _dataLogger = logger;
            _context = context;
        }

        

        [Authorize]
        public async Task<ViewResult> Index()
        {
            var user = await CurrentUser();

            ArduinoData data = new ArduinoData
            {
                DataId = 1,
                Plant = new Plant(),
                PlantId = 1,
                Temperature = 100,
                Light = 100,
                Moisture = 100,
                Water = 1000
            };

            EFArduinoDataRepository arduinoDataRepository = new EFArduinoDataRepository(_context);

            Plant plant = new Plant
            {
                User = user,
                PlantId = 1,
                Datas = new List<ArduinoData>(2),
                Name = "h36",
                DateAdded = DateTime.Now
            };

            EFPlantRepository efPlantRepository = new EFPlantRepository(_context);

            efPlantRepository.SavePlant(plant, user);

            arduinoDataRepository.SaveData(data);

            ArduinoData hey = _context.Data.FirstOrDefault(m => m.DataId == data.DataId);

            _context.SaveChanges();
            return View(user.Plants);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Description of your profile";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
