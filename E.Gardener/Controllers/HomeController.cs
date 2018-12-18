using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ArduinoObserver;
using Repository.Abstract;
using Repository.Concrete;
using Repository.Models;

namespace E.Gardener.Controllers
{
    public class HomeController : CController
    {
        private readonly Observer _dataLogger;
        private readonly IPlantRepository _plantRepository;

        public HomeController(Observer logger, IPlantRepository repository, UserManager<ApplicationUser> userManager) : base(userManager)
        {

           // EFArduinoDataRepository arduinoDataRepository = new EFArduinoDataRepository(_context);

          //  arduinoDataRepository.SaveData(new ArduinoData());

            _dataLogger = logger;
            _plantRepository = repository;
        }


        

        [Authorize]
        public async Task<string> Index()
        {
            var user = await CurrentUser();
            return user.Name;
            //return View();
        }

        public async Task<string> UpdateName()
        {
            
            var user = await CurrentUser();

           await _plantRepository.SavePlant(new Plant()
            {
                Name = "hey"
            });
            return _plantRepository.UserPlants().ToString();

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

        public string CreateTestPlant()
        {
            _plantRepository.SavePlant(new Plant()
            {
                Name = "hye"
            });
            return "shit";
        }

        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
