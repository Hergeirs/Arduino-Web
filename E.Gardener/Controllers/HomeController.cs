using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Repository.Abstract;
using Repository.Concrete;
using Repository.Models;

namespace E.Gardener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlantRepository _plantRepository;

        public HomeController(IPlantRepository repository)
        {

           // EFArduinoDataRepository arduinoDataRepository = new EFArduinoDataRepository(_context);

          //  arduinoDataRepository.SaveData(new ArduinoData());

            _plantRepository = repository;
        }


        

        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            return View(await _plantRepository.UserPlants());
        }

        public async Task<string> UpdateName()
        {
           await _plantRepository.SavePlant(new Plant()
            {
                Name = "hey"
            });
            return "done";

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
