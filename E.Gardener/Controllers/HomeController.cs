using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using ArduinoObserver;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;

namespace E.Gardener.Controllers
{
    public class HomeController : Controller
    {
        private readonly Observer _observer;
        private readonly Observable _observable;

        public HomeController(Observer observer, Observable observable)
        {
            _observer = observer;
            _observable = observable;
        }




        public IActionResult Index()
        {
            _observable.FetchData();
            return View(_observer.data);
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
