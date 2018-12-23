using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E.Gardener.Models;
using Microsoft.AspNetCore.Authorization;
using Repository;
using Repository.Abstract;
using Repository.Models;

namespace E.Gardener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IApplicationUserAccessor _userAccessor;


        public HomeController(IPlantRepository repository, IApplicationUserAccessor userAccessor)
        {
            // EFArduinoDataRepository arduinoDataRepository = new EFArduinoDataRepository(_context);

          //  arduinoDataRepository.SaveData(new ArduinoData());

            _plantRepository = repository;
            _userAccessor = userAccessor;
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
            return _plantRepository.UserPlants().ToString();

        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Description of your profile";

            var user = await _userAccessor.User;

            return View(user);
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
