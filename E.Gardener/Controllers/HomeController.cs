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
using Repository;

namespace E.Gardener.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataLogger _dataLogger;
        private readonly EGardenerContext _context;

        public HomeController(DataLogger logger, EGardenerContext context)
        {
            _dataLogger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_dataLogger.data.LastOrDefault());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            //_context.Users.Add(new User {Name = "Kristmund" });
            //_context.SaveChanges();


            return View(_context.Users.First(x => x.Name == "Kristmund"));
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
