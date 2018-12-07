using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using ArduinoObserver;
using E.Gardener.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;
using Microsoft.AspNetCore.Authorization;
using Repository;

namespace E.Gardener.Controllers
{
    public class HomeController : Controller
    {
        private readonly Observer _dataLogger;
        private readonly EGardenerContext _context;

        public HomeController(Observer logger, EGardenerContext context)
        {
            _dataLogger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            //var data = new List<ArduinoData> {_dataLogger.data.LastOrDefault()};
            var map = new Dictionary<uint, ArduinoData>();

            foreach (var arduinoData in _dataLogger.Data)
            {
            map.Add(arduinoData.PlantId, arduinoData);

            }

            //var dummy = new ArduinoData
            //{
            //    User = null,
            //    Light = 111,
            //    PlantId = 0,
            //    Temperature = 24,
            //    Water = 21,
            //    Moisture = 77
            //};

            //var dummy2 = new ArduinoData
            //{
            //    User = null,
            //    Light = 122,
            //    PlantId = 0,
            //    Temperature = 14,
            //    Water = 212,
            //    Moisture = 71
            //};


            //map.Add(0, dummy);
            //if (map.ContainsKey(dummy2.PlantId))
            //{
            //    map[dummy.PlantId] = dummy2;
            //}
            //else
            //{
            //map.Add(1, dummy2);

            //}
            return View(map.Values.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            //_context.Users.Add(new User {Name = "Kristmund" });
            //_context.SaveChanges();


            return View(_context.Users.First(x => x.Name == "Kristmund"));
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
