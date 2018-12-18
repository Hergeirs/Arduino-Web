using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ArduinoObserver;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Repository;
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

            EFArduinoDataRepository arduinoDataRepository = new EFArduinoDataRepository(_context);

            arduinoDataRepository.SaveData(new ArduinoData());

            _dataLogger = logger;
            _context = context;
            SavePlant();
        }


        public void SavePlant()
        {
            foreach (var data in _dataLogger.Data)
            {
                Plant plant = new Plant
                {
                    DateAdded = DateTime.Now,
                    PlantId = data.PlantId,
                };

                if (_context.Plants.Find(plant.PlantId) == null)
                {
                    _context.Add(plant);
                }
            }
        }
        

        [Authorize]
        public async Task<string> Index()
        {
            var user = await CurrentUser();
            return user.Email;

            //return View();
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
